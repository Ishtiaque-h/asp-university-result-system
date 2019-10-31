using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class StudentResultView
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
         [Required(ErrorMessage = "select RegNo  is required")]
         [DisplayName("Student RegNo ")]
        public int StudentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }


    }
}