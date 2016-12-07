using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = StudentRepository.Get(id);
            
            var viewModel = new StudentVM();
            viewModel.Student = student;
            if (viewModel.Student.Courses != null)
            {
                viewModel.SelectedCourseIds = student.Courses.Select(c => c.CourseId).ToList();
            }
            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetCourseItems(CourseRepository.GetAll());

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();
            foreach (var course in studentVM.SelectedCourseIds)
            {
                studentVM.Student.Courses.Add(CourseRepository.Get(course));
            }
            StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            StudentRepository.Edit(studentVM.Student);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var viewModel = new StudentVM();
            var student = StudentRepository.Get(id);
            viewModel.Student = student;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }

    }
}