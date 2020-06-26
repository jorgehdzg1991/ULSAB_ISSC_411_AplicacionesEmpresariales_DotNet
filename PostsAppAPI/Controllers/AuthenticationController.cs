using PostsAppAPI.Requests;
using PostsAppBLL;
using PostsAppBLL.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PostsAppAPI.Controllers
{
    [RoutePrefix("api/auth")]
    [EnableCors("*", "*", "*")]
    public class AuthenticationController : BaseController
    {
        [HttpPost]
        [Route("signIn")]
        public HttpResponseMessage SignInUser(SignInRequest request)
        {
            try
            {
                var session = AuthenticationBL.SignInUser(request.Email, request.Password);

                return Request.CreateResponse(HttpStatusCode.OK, session);
            }
            catch (WrongEmailOrPasswordException)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Wrong email or password." });
            }
            catch (Exception ex)
            {
                return HandleInternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("signUp")]
        public HttpResponseMessage SignUpUser(SignUpRequest request)
        {
            try
            {
                var session = AuthenticationBL.SignUpUser(request.Email, request.Handle, request.DisplayName, request.Password);

                return Request.CreateResponse(HttpStatusCode.OK, session);
            }
            catch (EmailAlreadyInUseException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Email already in use." });
            }
            catch (HandleAlreadyInUseException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Handle already in use." });
            }
            catch (Exception ex)
            {
                return HandleInternalServerError(ex);
            }
        }
    }
}