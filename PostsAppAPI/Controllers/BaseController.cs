using PostsAppAPI.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostsAppAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected string GetAuthenticationToken()
        {
            if (!Request.Headers.Contains("auth-token"))
            {
                throw new MissingAuthenticationTokenException();
            }

            return Request.Headers.GetValues("auth-token").FirstOrDefault();
        }

        protected HttpResponseMessage HandleInternalServerError(Exception ex)
        {
            Console.WriteLine($"500 Internal Server Error.");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}