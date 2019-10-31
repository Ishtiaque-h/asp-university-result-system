using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using Rotativa;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class StudentResultController : Controller
    {
        //
        // GET: /StudentResult/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();

        public ActionResult SaveStudentResult()
        {
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.Students = students;
            List<Course> courses = courseManager.GetAllCourse();
            ViewBag.Courses = courses;
            return View();
            
        }
        [HttpPost]
        public ActionResult SaveStudentResult(StudentResult studentResult )
        {
            ViewBag.Message = studentManager.SaveStudentResult(studentResult);
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.Students = students;
            List<Course> courses = courseManager.GetAllCourse();
            ViewBag.Courses = courses;
           
            return View();
        }

        public JsonResult GetStudentById(int studentId)
        {
            StudentVM student = studentManager.GetStudentWithDepartment(studentId);
            return Json(student);
        }

        public JsonResult GetCoursesTakenByStudentById(int studentId)
        {
            List<StudentCourse> studentCourses = studentManager.GetCoursesTakenByStudentById(studentId);
            return Json(studentCourses);
        }

        public ActionResult StudentResultView()
        {
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.Students = students;
            return View();
        }

        public JsonResult GetStudentResultsByStudentId(int studentId)
        {
            List<StudentResultView> resulViews = studentManager.GetStudentResultViewByStudentId(studentId);

            return Json(resulViews);
        }

        public ActionResult ViewResult(string studentName){
            ViewBag.Result = studentName;
            return View();
        }

        public ActionResult ExportPDF()
        {
            return new ActionAsPdf("StudentResultView")
            {
                FileName = Server.MapPath("/content/Student Info.pdf")
            };
        }

	}
}