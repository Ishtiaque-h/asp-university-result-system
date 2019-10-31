using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class StudentCourseView
    {

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int DepartmentId { get; set; }   

        public int AssignFlag { get; set; }

        public int StudentId { get; set; }

    }
}