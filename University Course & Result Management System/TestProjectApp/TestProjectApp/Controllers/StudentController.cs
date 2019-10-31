using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        DepartManager departManager = new DepartManager();
        //
        // GET: /Student/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult SaveStudent()
        {
            List<Department> departments = departManager.GetAllDepartments();
            ViewBag.Deapartments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudent(Student student)
        {
            ViewBag.Message = studentManager.SaveStudent(student);

            if (ViewBag.Message != null)
            {
                return RedirectToAction("ViewStudentInfo", "Student");
            }

            List<Department> departments = departManager.GetAllDepartments();
            ViewBag.Deapartments = departments;
            return View();
        }


        public ActionResult ViewStudentInfo()
        {

            Student aStudent = new Student();

            aStudent = studentManager.GetStudentInfo();

            ViewBag.StudentInfo = aStudent;

            return View();
        }

       
    }
}