using Logic;
using ProtalOfLife.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtalOfLife.UI.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult ApplicationHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplicationHome(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
                grinder.AddApplicant(applicant);
                return RedirectToAction("ConfirmApplication");
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult ConfirmApplication(string name)
        {
            Applicant applicant = new Applicant();
            applicant.FirstName = name;
            return View(applicant);
        }
    }
}