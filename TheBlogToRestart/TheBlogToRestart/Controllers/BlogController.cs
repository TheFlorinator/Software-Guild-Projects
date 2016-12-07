using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheBlogToRestart.Logic;
using TheBlogToRestart.Models;

namespace TheBlogToRestart.Controllers
{
    public class BlogController : ApiController
    {
        private Rules _rules;

        public BlogController()
        {
            _rules = new Rules();
        }

        //[HttpGet]
        //public List<Post> GetSomething(string butter)
        //{
        //    var response = _rules.SearchByHashTag(butter);
        //    return response.Post;
        //}

        [HttpGet]
        public List<Post> All()
        {
            var response = _rules.GetTopFive();
            response.Message = "";
            return response.Post;            
        }

        [HttpGet]
        public Post MostRecent()
        {
           return _rules.GetMostRecent().Post;       

        }
       

        public HttpResponseMessage Post(Post post)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, post);
            if (ModelState.IsValid)
            {
                _rules.AddPost(post);
                string uri = Url.Link("DefaultApi", new { id = post.PostId });
                response.Headers.Location = new Uri(uri);
            }
            else
            {
                ModelState.AddModelError("key", "message");
            }
            return response;
        }

        public HttpResponseMessage Put(Post post)
        {
            _rules.EditPost(post);

            var response = Request.CreateResponse(HttpStatusCode.Created, post);
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
           // _rules.RemovePost(id);

            var response = Request.CreateResponse(HttpStatusCode.Accepted, id);
            return response;
        }

       
    }
}
