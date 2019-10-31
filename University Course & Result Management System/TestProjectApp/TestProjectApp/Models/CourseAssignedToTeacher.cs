using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class CourseAssignedToTeacher
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]

        [DisplayName("Course Code")]
        public string CourseCode { get; set; }

        [DisplayName("Course Code")]
        public int CourseId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [DisplayName("Credit To Be Taken")]
        public double CreditToBeTaken { get; set; }

        [DisplayName("Remaining Credit")]
        public double RemainingCredit { get; set; }

        [DisplayName("Course Name")]
        public string CourseName { get; set; }

        [DisplayName("Course Credit")]
        public double CourseCredit { get; set; }


    }
}