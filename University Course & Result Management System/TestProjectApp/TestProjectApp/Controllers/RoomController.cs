using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProjectApp.Manager;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    public class RoomController : Controller
    {

        RoomManager aRoomManager = new RoomManager();
        
        public ActionResult SaveRoom()
        {
            List<Department> departments = new List<Department>();

            departments = aRoomManager.GetAllDepartments();

            ViewBag.Departments = departments;

            List<RoomInfo> rooms = new List<RoomInfo>();
            List<RoomInfo> days = new List<RoomInfo>();

            rooms = aRoomManager.GetAllRooms();
            days = aRoomManager.GetAllDays();

            ViewBag.Rooms = rooms;
            ViewBag.Days = days;

            return View();
        }


        [HttpPost]
        public ActionResult SaveRoom(RoomInfo aRoomInfo)
        {
            List<Department> departments = new List<Department>();

            departments = aRoomManager.GetAllDepartments();

            ViewBag.Departments = departments;

            List<RoomInfo> rooms = new List<RoomInfo>();
            List<RoomInfo> days = new List<RoomInfo>();

            rooms = aRoomManager.GetAllRooms();
            days = aRoomManager.GetAllDays();

            ViewBag.Rooms = rooms;
            ViewBag.Days = days;

            ViewBag.Message = aRoomManager.SaveRoomInfo(aRoomInfo);


            return View();
        }

        
        public ActionResult UnallocateRooms()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult UnallocateRooms(RoomInfo aRoomInfo)
        {
            ViewBag.Message = aRoomManager.UnallocateRooms();
            return View();
        }



        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courses = aRoomManager.GetCoursesByDepartmentId(departmentId);
            return Json(courses);
        }

        public ActionResult ViewRoomSchedule()
        {
            List<Department> departments = new List<Department>();

            departments = aRoomManager.GetAllDepartments();

            ViewBag.Departments = departments;

            return View();
        }

        public JsonResult GetCourseScheduleByDepartmentId(int departmentId)
        {
            List<RoomScheduleViewModel> roomSchedule = aRoomManager.GetAllRoomSchedule(departmentId);
            return Json(roomSchedule);
        }
	}
}