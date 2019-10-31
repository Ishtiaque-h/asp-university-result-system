using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager teacherManager = new TeacherManager();
         DepartManager departManager = new DepartManager();
        //
        // GET: /Teacher/
        //public ActionResult Index()
        //{
           
        //    return View();
        //}

        public ActionResult SaveTeacher()
        {
             List<Designation> designations = teacherManager.GetAllDesignation();
            ViewBag.Designations = designations;
              List<Department> departments = departManager.GetAllDepartments();
            ViewBag.Deapartments = departments;
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            ViewBag.Teaher = teacherManager.SaveTeacher(teacher);
            List<Designation> designations = teacherManager.GetAllDesignation();
            ViewBag.Designations = designations;
            List<Department> departments = departManager.GetAllDepartments();
            ViewBag.Deapartments = departments;
            return View();
        }
	}
}