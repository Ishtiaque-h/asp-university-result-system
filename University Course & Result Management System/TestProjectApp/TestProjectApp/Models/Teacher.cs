using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

         [Required(ErrorMessage = "Teacher name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]

        //[RegularExpression(@"a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?]", ErrorMessage = "Please enter a valid mail")]
        public string Email { get; set; }
      
        [Required(ErrorMessage = "Contact No is required")]
        [DisplayName("Contact No. :")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Desigmation name is required")]
        [DisplayName("Designation Name")]
        public int DesignatonId { get; set; }
        
        [Required(ErrorMessage = "Departmentt name is required")]
        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Credit name is required")]
        public decimal CreditTaken { get; set; }
         [Required(ErrorMessage = "Student name is required")]
        public decimal RemainingCrdeit { get; set; }

    }
}