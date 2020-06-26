using PostsAppBLL;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PostsAppAPI.Controllers
{
    [RoutePrefix("api/profiles")]
    [EnableCors("*", "*", "*")]
    public class UsersProfilesController : BaseController
    {
        [HttpGet]
        [Route("find/{handle}")]
        public HttpResponseMessage FindProfileByHandle(string handle)
        {
            try
            {
                var profile = UsersProfilesBL.FindUserProfileByHandle(handle);

                return Request.CreateResponse(HttpStatusCode.OK, profile);
            }
            catch (Exception ex)
            {
                return HandleInternalServerError(ex);
            }
        }
    }
}