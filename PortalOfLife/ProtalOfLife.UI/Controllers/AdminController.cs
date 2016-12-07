using Logic;
using ProtalOfLife.Data.Repos;
using ProtalOfLife.Models.Data;
using ProtalOfLife.Models.Responses;
using ProtalOfLife.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtalOfLife.UI.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Categories()
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            var viewModel = new CategoryVM();
            var categoryList = grinder.GetAllCategoryies();
            viewModel.CategoryList = categoryList;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Categories(int categoryId)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            var viewModel = new CategoryVM();
            var categoryList = grinder.GetAllCategoryies();
            viewModel.CategoryList = categoryList;
            viewModel.Category = categoryList.FirstOrDefault(c => c.Id == categoryId);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Policy(string id, string reference)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            Policy newPolicy = new Policy();
            if (reference != null && reference == "categories")
            {
                ViewBag.LinkText = "Return to View Policies";
                ViewBag.LinkAction = "Categories";
                ViewBag.LinkController = "Admin";
            }
            else
            {
                ViewBag.LinkText = "Return to Manage Policies";
                ViewBag.LinkAction = "ManagePolicies";
                ViewBag.LinkController = "Admin";
            }
            newPolicy.Name = id;
            var policySearched = grinder.GetOnePolicy(newPolicy);
            return View(policySearched);
        }

        [HttpGet]
        public ActionResult ManagePolicies()
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            var viewModel = new CategoryVM(); 
            viewModel.CategoryList = grinder.GetAllCategoryies();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ManagePolicies(int categoryId)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            var viewModel = new CategoryVM();
            var categoryList = grinder.GetAllCategoryies();
            viewModel.CategoryList = categoryList;
            viewModel.Category = categoryList.FirstOrDefault(c => c.Id == categoryId);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DeletePolicy(string name)
        {
            Policy policy = new Policy();
            policy.Name = name;
            return View(policy);
        }

        [HttpPost]
        public ActionResult DeletePolicy(Policy policy)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            grinder.DeletePolicy(policy);
            return RedirectToAction("ManagePolicies");
        }

        [HttpGet]
        public ActionResult AddPolicy(int CategoryId)
        {
            Policy policy = new Policy();
            return View(policy);
        }

        [HttpPost]
        public ActionResult AddPolicy(Policy policy)
        {
            if (ModelState.IsValid)
            {
                PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
                PolicyResponse response = grinder.AddNewPolicy(policy);
                return RedirectToAction("ManagePolicies", response);
            }
            return View(policy);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
                CategoryResponse response = grinder.AddNewCategory(category);
                return RedirectToAction("ManagePolicies", response);
            }
            return View(new Category());
        }

        [HttpGet]
        public ActionResult ViewCategories()
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            CategoryVM viewModel = new CategoryVM();
            viewModel.CategoryList = grinder.GetAllCategoryies();   
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DeleteCategory(string categoryName)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            CategoryResponse category = grinder.GetOneCategory(categoryName);
            return View(category);
        }

        [HttpPost]
        public ActionResult DeleteThatCategory(string categoryName)
        {
            PolicyGrinder grinder = PolicyGrinderFactory.Synthesize();
            grinder.DeleteCategory(categoryName);
            return RedirectToAction("ViewCategories");
        }
    }
}