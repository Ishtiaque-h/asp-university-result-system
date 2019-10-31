using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class CourseAssignedToTeacherController : Controller
    {
        CourseAssignedToTeacherManager aManager = new CourseAssignedToTeacherManager();
        //
        // GET: /CourseAssignedToTeacher/
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult SaveAssignedTeacher()
        {
            List<Department> departments = aManager.GetAllDepartments();
            ViewBag.Departments = departments;            
            return View();
        }

        [HttpPost]

        public ActionResult SaveAssignedTeacher(CourseAssignedToTeacher aCourseAssignedToTeacher)
        {
            List<Department> departments = aManager.GetAllDepartments();
            ViewBag.Departments = departments;
            ViewBag.Message = aManager.SaveCourseAssigned(aCourseAssignedToTeacher);
            return View();
        }

        

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            List<Teacher> teachers = GetTeachers();
            List<Teacher> teachersList =teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teachersList);
        }

        public JsonResult GetAllUnAssignedCourses(int departmentId)
        {
            List<Course> courses = aManager.GetAllUnAssignedCourses(departmentId);
            //List<Teacher> teachersList =teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courses);
        }
        public JsonResult GetCourseById(int courseId)
        {
            Course course = aManager.GetCourseDetails(courseId);
            return Json(course);
        }

        public JsonResult GetTeacherDetails(int teacherId)
        {
            Teacher aTeacher= aManager.GetTeacherDetails(teacherId);
            return Json(aTeacher);
        }

        private List<Teacher> GetTeachers()
        {
            return aManager.GetTeachers();
        }
    }
}