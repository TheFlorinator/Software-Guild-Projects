using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheBlogToRestart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //TheBlogToRestart.Models.BlogContext context = new Models.BlogContext();
            //var post = context.Posts.ToList();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}