using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class CourseStatisticsViewModel
    {
        [DisplayName("Department Id")]
        public int DeptId { get; set; }

        
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public string SemesterName { get; set; }
        public string AssignedTo { get; set; }

    }
}