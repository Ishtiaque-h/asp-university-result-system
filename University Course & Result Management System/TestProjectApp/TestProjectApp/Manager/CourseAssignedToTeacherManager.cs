using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProjectApp.Gateway;
using TestProjectApp.Models;

namespace TestProjectApp.Manager
{
    public class CourseAssignedToTeacherManager
    {
        CourseAssignedToTeacherGateway aGateway = new CourseAssignedToTeacherGateway();
        public List<Department> GetAllDepartments()
        {
           
            return aGateway.GetAllDepartments();
        }



        public string SaveCourseAssigned(CourseAssignedToTeacher aCourseAssignedToTeacher)
        {
            bool hasCourse = aGateway.IsCourseAssigned(aCourseAssignedToTeacher);

            if (hasCourse)
            {
                return "This course has already been assigned";
            }

            else
            {
                int rowsAffected = aGateway.SaveCourseAssigned(aCourseAssignedToTeacher);
                if (rowsAffected > 0)
                {
                    return "Course has been assigned successfully";
                }
                return "An error occured";
            }
        }

        public List<Teacher> GetTeachers()
        {
            return aGateway.GetTeachers();
        }

        public List<Course> GetAllUnAssignedCourses(int departmentId)
        {
            return aGateway.GetAllUnAssignedCourses(departmentId);
        }

        public Course GetCourseDetails(int courseId)
        {
            return aGateway.GetCourseDetails(courseId);
        }

        public Teacher GetTeacherDetails(int teacherId)
        {
            return aGateway.GetTeacherDetails(teacherId);
        }
    }
}