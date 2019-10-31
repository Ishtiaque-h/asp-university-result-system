using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProjectApp.Gateway;
using TestProjectApp.Models;

namespace TestProjectApp.Manager
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();
        public string SaveCourse(Course course)
        {
            bool isCodeExists = courseGateway.IsCodeExists(course);
            bool isNameExists = courseGateway.IsNameExists(course);

            if (isCodeExists)
            {
                return "There is already a course with this code";
            }

            if (isNameExists)
            {
                return "There is already another course in this name";
            }

            else
            {
                int row = courseGateway.SaveCourse(course);

                if (row > 0)
                {
                    return "Course information saved Successfully";
                }
                else
                {
                    return "An error occured";
                }
            }
        }

        public List<Semester> GetAllSemester()
        {
            return courseGateway.GetAllSemester();
        }

        public List<Course> GetAllCourse()
        {
            return courseGateway.GetAllCourse();
        }



    }
}