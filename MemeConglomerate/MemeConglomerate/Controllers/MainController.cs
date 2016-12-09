using MemeConglomerate.Logic;
using MemeConglomerate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemeConglomerate.Controllers
{
    public class MainController : Controller
    {
        private MemeManager _manager;
        public MainController()
        {
            _manager = new MemeManager();
        }
        public ActionResult Index()
        {
            var viewModel = new GenreView();
            var genres = _manager.GetAllGenre();
            viewModel.SetGenres(genres);
            return View(viewModel);
        }
    }
}