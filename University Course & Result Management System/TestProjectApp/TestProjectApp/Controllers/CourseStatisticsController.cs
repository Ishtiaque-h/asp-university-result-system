using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class CourseStatisticsController : Controller
    {
        //
        // GET: /CourseStatistics/
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ViewInformation()
        {
            ViewStatisticsManager aViewStatisticsManager=new ViewStatisticsManager();
            ViewBag.Departments=aViewStatisticsManager.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult ViewInformation(CourseStatisticsViewModel aCourseStatisticsViewModel)
        {
            ViewStatisticsManager aViewStatisticsManager = new ViewStatisticsManager();
            ViewBag.Departments = aViewStatisticsManager.GetAllDepartments();
            return View();
        }

        //[HttpPost]
        //public ActionResult ViewInformation(int departmentId)
        //{
        //    ViewStatisticsManager aViewStatisticsManager=new ViewStatisticsManager();
        //    List<CourseStatisticsViewModel> aCourseStatisticsViewModels= aViewStatisticsManager.GetAllInformation();

        //    ViewBag.Information = aCourseStatisticsViewModels;
        //    return View();
        //}

        public JsonResult GetAllInformation(int departmentId)
        {
            ViewStatisticsManager aViewStatisticsManager = new ViewStatisticsManager();
            List<CourseStatisticsViewModel> aCourseStatisticsViewModels= aViewStatisticsManager.GetAllInformation(departmentId);
            return Json(aCourseStatisticsViewModels);
        }
    }
}