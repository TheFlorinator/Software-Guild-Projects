using LeagueOfBaseball.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfBaseball.UI.Controllers
{
    public class MainController : Controller
    {
        private League _league;

        public MainController()
        {
            //_league = new League();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}