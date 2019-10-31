using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class CourseController : Controller
    {
        CourseManager courseManager = new CourseManager();
        DepartManager departManager = new DepartManager();
        //
        // GET: /Course/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult SaveCourse()
        {
            List<Department> departments = departManager.GetAllDepartments();
            ViewBag.Deapartments = departments;
            List<Semester> semesters = courseManager.GetAllSemester();
            ViewBag.Semesters = semesters;
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            List<Semester> semesters = courseManager.GetAllSemester();
            ViewBag.Semesters = semesters;
            List<Department> departments = departManager.GetAllDepartments();
            ViewBag.Deapartments = departments;

            ViewBag.Message = courseManager.SaveCourse(course);
            
            return View();
        }
	}
}