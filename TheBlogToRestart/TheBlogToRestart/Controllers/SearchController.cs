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
    public class SearchController : ApiController
    {
        private Rules _rules;

        public SearchController()
        {
            _rules = new Rules();
        }

        [HttpGet]
        public Post GetSnow(int number)
        {
            return _rules.GetOnePost(number).Post;
        }


        [HttpGet]
        public List<Post> GetZzzz()
        {
            var response = _rules.GetTopTen();
            return response.Post;
        }

        [HttpGet]
        public List<Post> GetZebra(string zebra)
        {
            var response = _rules.SearchByHashTag(zebra);
            return response.Post;
        }
    }
}
