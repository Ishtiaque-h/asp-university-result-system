using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProjectApp.Gateway;
using TestProjectApp.Models;

namespace TestProjectApp.Manager
{
    public class RoomManager
    {

        RoomGateway aRoomGateway = new RoomGateway();

        public List<Department> GetAllDepartments()
        {
            return aRoomGateway.GetAllDepartments();
        }

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            return aRoomGateway.GetCoursesByDepartmentId(departmentId);
        }

        public List<RoomInfo> GetAllDays()
        {
            return aRoomGateway.GetAllDays();
        }

        public List<RoomInfo> GetAllRooms()
        {
            return aRoomGateway.GetAllRooms();
        }

        public string SaveRoomInfo(RoomInfo aRoomInfo)
        {

            bool isOverlapping = aRoomGateway.IsOverlapping(aRoomInfo);

            if (isOverlapping)
            {
                return "Sorry, the time you selected overlaps with another course";
            }

            List<RoomInfo> rooms = new List<RoomInfo>();

            rooms = aRoomGateway.GetAllTimes();

            foreach (RoomInfo aRoom in rooms)
            {
                isOverlapping = aRoomGateway.IsAnotherOverLapping(aRoom, aRoomInfo);

                if (isOverlapping)
                {
                    return "Sorry, the time you selected overlaps with another schedule";
                }
            }

            int rowAffected = aRoomGateway.SaveRoomInfo(aRoomInfo);

            if (rowAffected > 0)
            {
                return "Room allocation successfull";
            }

            return "An error occured";
        }

        public List<RoomScheduleViewModel> GetAllRoomSchedule(int departmentId)
        {
            List<RoomScheduleViewModel> aRoomSchedule =  aRoomGateway.ViewRoomSchedule(departmentId);

            foreach (RoomScheduleViewModel aRoomInfo in aRoomSchedule)
            {
                aRoomInfo.RoomDescription = aRoomGateway.GetRoomDescription(aRoomInfo.CourseId);

                if (aRoomInfo.RoomDescription==null)
                {
                    aRoomInfo.RoomDescription = "Not scheduled yet";
                }
            }

            return aRoomSchedule;
        }


        public string UnallocateRooms()
        {
            int rowAffected = aRoomGateway.UnallocateRooms();

            if (rowAffected > 0)
            {
                return "All room schedules have been unallocated successfully";
            }

            return "All rooms have been unallocated already or an error occured";
        }
    }
}