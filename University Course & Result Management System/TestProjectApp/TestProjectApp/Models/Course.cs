using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class Course
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "code is required")]
         [MinLength(5, ErrorMessage = "Code must be at lest 5  characters  long")]
        public string Code { get; set; }
         [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
         [Required(ErrorMessage = "Credit is required")]
         [Range(.5, 5, ErrorMessage = "Enter number between .5 to 5")]
        public decimal Credit { get; set; }
         [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
         [Required(ErrorMessage = "Department name is required")]
        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }
         [Required(ErrorMessage = "Semesteris required")]
         [DisplayName("Semester Name")]
        public int SemesterId { get; set; }

    }
}