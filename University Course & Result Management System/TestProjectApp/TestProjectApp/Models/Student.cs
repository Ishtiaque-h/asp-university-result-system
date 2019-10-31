using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProjectApp.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [DisplayName("Student Name")]
        
        public string Name { get; set; }

        public string RegNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        //[RegularExpression(@"a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?]", ErrorMessage="Please enter a valid mail")]
       
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact No. is required")]
        [DisplayName("Contact Number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}