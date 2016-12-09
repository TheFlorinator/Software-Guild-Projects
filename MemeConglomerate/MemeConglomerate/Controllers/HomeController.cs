using MemeConglomerate.Logic;
using MemeConglomerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemeConglomerate.Controllers
{
    public class HomeController : ApiController
    {
        private MemeManager _manager;
        public HomeController()
        {
            _manager = new MemeManager();
        }

        [HttpGet]
        public List<Meme> AllMemes()
        {
            var memes = _manager.GetAllMemes();
            return memes;
        }

        [HttpGet]
        public List<Genre> AllGenres()
        {
            var genres = _manager.GetAllGenre();
            return genres;
        }

        [HttpGet]
        public List<Meme> Search(string genre)
        {
            var searchedMemes = _manager.SearchMemes(genre).ToList();
            return searchedMemes;
        }

        [HttpPost]
        public HttpResponseMessage Post(Meme meme)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, meme);
            _manager.AddMeme(meme);
            string uri = Url.Link("DefaultApi", new { id = meme.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
