using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheBlogToRestart.Logic;
using TheBlogToRestart.Models;
using TheBlogToRestart.ViewModels;



namespace TheBlogToRestart.Controllers
{
    public class TagController : ApiController
    {
        private Rules _rules;

        public TagController()
        {
            _rules = new Rules();
        }

        [HttpPost]
        public Tag Save(Tag tag)
        {
            return _rules.SaveTag(tag).Post;
        }

        [HttpGet]
        public List<Tag> GetAll()
        {
            return _rules.GetAllTags();
        }
    }
}
