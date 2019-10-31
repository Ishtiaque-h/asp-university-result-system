using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class RoomScheduleViewModel
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string CourseCode { get; set; }

        public string Room { get; set; }

        public string RoomDescription { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string Day { get; set; }

        public string FromTime { get; set; }

        public string ToTime { get; set; }

        public string AssignFlag { get; set; }

    }
}