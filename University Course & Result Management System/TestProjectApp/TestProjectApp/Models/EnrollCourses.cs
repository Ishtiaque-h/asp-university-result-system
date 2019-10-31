using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class EnrollCourses
    {
        public int  Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool Status { get; set; }

    }
}