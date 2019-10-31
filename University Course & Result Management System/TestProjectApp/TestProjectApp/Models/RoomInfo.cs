using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class RoomInfo
    {
        public int  Id { get; set; }


        [Required(ErrorMessage = "Please select a Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select a Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please select a Room")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Please select a Day")]
        public int DayId { get; set; }

        public string DayName { get; set; }
        
        public string RoomName { get; set; }


        [Required(ErrorMessage = "Please select start time")]
        public string FromTime { get; set; }

        [Required(ErrorMessage = "Please select end time")]
        public string ToTime { get; set; }

    }
}