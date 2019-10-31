using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class EnrollStudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();
        [HttpGet]
        public ActionResult Enroll()
        {
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.Students = students;
            List<Course> courses = courseManager.GetAllCourse();
            ViewBag.Courses = courses;
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(EnrollCourses enroll)
        {
            ViewBag.Message = studentManager.EnrollCourseSave(enroll);
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

        public JsonResult GetCourseByStudentId(int studentId)
        {
            Student student = studentManager.GetAllStudent().ToList().Find(st => st.Id == studentId);
            List<Course> courses = courseManager.GetAllCourse().ToList().FindAll(d => d.DepartmentId == student.DepartmentId);
            return Json(courses);

        }
    }
}