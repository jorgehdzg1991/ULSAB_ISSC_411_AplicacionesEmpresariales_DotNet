using PostsAppJWT.Managers;
using PostsAppJWT.Models;
using Microsoft.IdentityModel.Tokens;
using PostsAppDAL;
using PostsAppModels.Authentication;
using System.Configuration;
using System.Security.Claims;
using System.Linq;
using System;
using PostsAppBLL.Exceptions;
using System.Text;
using PostsAppDAL.Exceptions;

namespace PostsAppBLL
{
    public class AuthenticationBL
    {
        public static readonly string SessionSecretKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["SessionSecretKey"]));

        public static class JWTTokenTypes
        {
            public const string Auth = "auth";
            public const string Refresh = "refresh";
        }

        #region Authentication Process Methods

        public static Session SignUpUser(string email, string handle, string displayName, string password)
        {
            try
            {
                UsersDataAccess.SignUpUser(email, handle, displayName, password);

                return CreateSession(email, handle, displayName, "");
            }
            catch (DuplicateKeyException ex)
            {
                if (ex.Message.Contains("PRIMARY"))
                {
                    throw new EmailAlreadyInUseException();
                }
                else
                {
                    throw new HandleAlreadyInUseException();
                }
            }
        }

        public static Session SignInUser(string email, string password)
        {
            var user = UsersDataAccess.FindUserByEmailAndPassword(email, password);

            if (user == null)
            {
                throw new WrongEmailOrPasswordException();
            }

            return CreateSession(user.Email, user.Handle, user.DisplayName, user.Bio);
        }

        #endregion

        #region Utility Methods for Authentication

        internal static void ValidateAuthToken(string authToken, string email)
        {
            var jwtService = new JWTService(SessionSecretKey);

            if (jwtService.IsTokenValid(authToken))
            {
                var claims = jwtService.GetTokenClaims(authToken);

                try
                {
                    if (claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email)).Value != email ||
                        claims.FirstOrDefault(c => c.Type.Equals("TokenType")).Value != JWTTokenTypes.Auth)
                    {
                        throw new UnauthorizedAccessException("JWT Token is invalid.");
                    }
                }
                catch (Exception)
                {
                    throw new UnauthorizedAccessException("JWT Token is invalid.");
                }
            }
            else
            {
                throw new UnauthorizedAccessException("JWT token is invalid.");
            }
        }

        private static Session CreateSession(string email, string handle, string displayName, string bio)
        {
            var authTokenContainerModel = new JWTContainerModel(SessionSecretKey, SecurityAlgorithms.HmacSha256Signature, 1440, new Claim[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim("TokenType", JWTTokenTypes.Auth)
            });

            var refreshTokenContainerModel = new JWTContainerModel(SessionSecretKey, SecurityAlgorithms.HmacSha256Signature, 44640, new Claim[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim("TokenType", JWTTokenTypes.Refresh)
            });

            var jwtService = new JWTService(SessionSecretKey);

            var authTokenExpireTime = new DateTimeOffset(DateTime.UtcNow.AddMinutes(Convert.ToInt32(authTokenContainerModel.ExpireMinutes))).ToUnixTimeSeconds();
            var refreshTokenExpireTime = new DateTimeOffset(DateTime.UtcNow.AddMinutes(Convert.ToInt32(refreshTokenContainerModel.ExpireMinutes))).ToUnixTimeSeconds();

            var authToken = new SessionToken(authTokenExpireTime, jwtService.GenerateToken(authTokenContainerModel));
            var refreshToken = new SessionToken(refreshTokenExpireTime, jwtService.GenerateToken(refreshTokenContainerModel));

            return new Session(email, handle, displayName, bio, authToken, refreshToken);
        }

        #endregion
    }
}
