﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProjectApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string DepartmentName { get; set; }

    }
}