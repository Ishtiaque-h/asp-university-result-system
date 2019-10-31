using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string GradeLetter { get; set; }
       
    }
}