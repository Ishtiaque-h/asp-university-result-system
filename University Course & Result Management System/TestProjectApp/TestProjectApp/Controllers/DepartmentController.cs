using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class DepartmentController : Controller
    {

        DepartManager departManager = new DepartManager();
        public ActionResult Index()
        {
            List<Department> departments = departManager.GetAllDepartments();
            return View(departments);
        }

        public ActionResult SaveDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            ViewBag.Message = departManager.SaveDepartment(department);
            return View();
        }
	}
}