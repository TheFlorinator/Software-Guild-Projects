using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheBlogToRestart.Logic;
using TheBlogToRestart;
using TheBlogToRestart.Models;
using TheBlogToRestart.ViewModels;

namespace TheBlogToRestart.Controllers
{
    public class PostController : Controller
    {
        Rules rules = new Rules();

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Owner, Admin, Writer")]
        [HttpGet]
        public ActionResult WritePost()
        {
            PostVM vm = new PostVM();
            vm.HashTags = rules.GetAllTags();
            return View(vm);
        }

        [HttpPost]
        public ActionResult WritePost(Post p)
        {
            rules.AddPost(p);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Post()
        {
            return View();
        }

        [Authorize(Roles = "Owner, Admin")]
        [HttpGet]
        public ActionResult Publish(int id)
        {
            var response = rules.GetOnePost(id);
            return View(response.Post);
        }
        // This needs to be set up so the post saves and publishes
        [HttpPost]
        public ActionResult Publish(Post p)
        {
            
            rules.EditPost(p);
            return RedirectToAction("Index","Home" );
        }

        [Authorize(Roles = "Owner, Admin")]
        [HttpGet]
        public ActionResult Review()
        {
            var response = rules.GetUnpublishedPosts();
            IEnumerable<Post> p = response.Post;
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var response = rules.GetAllPublishedPosts();
            IEnumerable<Post> p = response.Post;
            return View(p);
        }
        [HttpGet]
        public ActionResult AboutUs()
        {
            var response = rules.GetAboutUsPosts();
            IEnumerable<Post> p = response.Post;
            return View(p);
        }
    }
}

