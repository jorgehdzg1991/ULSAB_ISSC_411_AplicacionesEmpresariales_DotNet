using PostsAppAPI.Exceptions;
using PostsAppAPI.Requests;
using PostsAppBLL;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PostsAppAPI.Controllers
{
    [RoutePrefix("api/posts")]
    [EnableCors("*", "*", "*")]
    public class PostsController : BaseController
    {
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreatePost(CreatePostRequest request)
        {
            try
            {
                var authToken = GetAuthenticationToken();

                var post = PostsBL.CreatePost(request.UsersEmail, request.Title, request.Content, authToken);

                return Request.CreateResponse(HttpStatusCode.OK, post);
            }
            catch(MissingAuthenticationTokenException)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
            catch(UnauthorizedAccessException)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                return HandleInternalServerError(ex);
            }
        }
    }
}