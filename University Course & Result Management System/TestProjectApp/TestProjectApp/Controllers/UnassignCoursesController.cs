using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;

namespace TestProjectApp.Controllers
{
    public class UnassignCoursesController : Controller
    {
        //
        // GET: /UnassignCourses/
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unassign(int ?id)
        {
            UnassignCoursesManager aUnassignCoursesManager = new UnassignCoursesManager();
            ViewBag.Message = aUnassignCoursesManager.UnassignCourses();
            return View();
        }
     }
}