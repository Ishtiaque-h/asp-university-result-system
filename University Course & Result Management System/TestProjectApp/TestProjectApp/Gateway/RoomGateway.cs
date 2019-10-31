using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TestProjectApp.Models;

namespace TestProjectApp.Gateway
{
    public class RoomGateway:Gateway
    {
        public int SaveRoomInfo(RoomInfo aRoomInfo)
        {
            Query = "INSERT INTO RoomSchedule VALUES('"+aRoomInfo.DepartmentId+"','"+aRoomInfo.CourseId+"','"+aRoomInfo.RoomId+"','"+aRoomInfo.DayId+"','"+aRoomInfo.FromTime+"','"+aRoomInfo.ToTime+"','1')";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsOverlapping(RoomInfo aRoomInfo)
        {
            Query = "DECLARE @Hello time = CAST('" + aRoomInfo.FromTime + "' as datetime) + CAST('00:00' AS datetime), @Hello2 time = CAST('" + aRoomInfo.ToTime + "' as datetime) - CAST('00:01' AS datetime) SELECT * FROM RoomSchedule  WHERE RoomId='" + aRoomInfo.RoomId + "' AND AssignFlag='1' AND DayId='" + aRoomInfo.DayId + "' AND FromTime BETWEEN @Hello AND @Hello2";

            Command = new  SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isoverlapped = false;

            if (Reader.HasRows)
            {
                isoverlapped = true;
            }

            if (isoverlapped)
            {
                return isoverlapped;
            }

            Reader.Close();
            Connection.Close();

            Query = "DECLARE @Hello time = CAST('" + aRoomInfo.FromTime + "' as datetime) + CAST('00:01' AS datetime), @Hello2 time = CAST('" + aRoomInfo.ToTime + "' as datetime) - CAST('00:00' AS datetime) SELECT * FROM RoomSchedule WHERE RoomId='" + aRoomInfo.RoomId + "' AND AssignFlag='1' AND DayId='" + aRoomInfo.DayId + "' AND ToTime BETWEEN @Hello AND @Hello2";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();


            if (Reader.HasRows)
            {
                isoverlapped = true;
            }

            Reader.Close();
            Connection.Close();

            return isoverlapped;
        }

        public int UnallocateRooms()
        {
            Query = "UPDATE RoomSchedule SET AssignFlag = '0'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsAnotherOverLapping(RoomInfo aRoomInfo, RoomInfo anotherRoomInfo)
        {
            Query = "DECLARE @Hello time = CAST('" + aRoomInfo.FromTime + "' as datetime) + CAST('00:01' AS datetime), @Hello2 time = CAST('" + aRoomInfo.ToTime + "' as datetime) - CAST('00:00' AS datetime) SELECT * FROM RoomSchedule WHERE RoomId='" + anotherRoomInfo.RoomId + "' AND AssignFlag='1' AND DayId='" + anotherRoomInfo.DayId + "' AND '" + anotherRoomInfo.ToTime + "' BETWEEN @Hello AND @Hello2";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isoverlapped = false;

            if (Reader.HasRows)
            {
                isoverlapped = true;
            }

            if (isoverlapped)
            {
                return isoverlapped;
            }

            Reader.Close();
            Connection.Close();

            Query = "DECLARE @Hello time = CAST('" + aRoomInfo.FromTime + "' as datetime) + CAST('00:00' AS datetime), @Hello2 time = CAST('" + aRoomInfo.ToTime + "' as datetime) - CAST('00:01' AS datetime) SELECT * FROM RoomSchedule WHERE RoomId='" + anotherRoomInfo.RoomId + "' AND AssignFlag='1' AND DayId='" + anotherRoomInfo.DayId + "' AND '" + anotherRoomInfo.FromTime + "' BETWEEN @Hello AND @Hello2";

            Command = new SqlCommand(Query, Connection);

            
            Connection.Open();

            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                isoverlapped = true;
            }

            Reader.Close();
            Connection.Close();

            return isoverlapped;
        }

        public List<RoomInfo> GetAllTimes()
        {
            List<RoomInfo> rooms = new List<RoomInfo>();

            Query = "SELECT * FROM RoomSchedule";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                RoomInfo aRoomInfo = new RoomInfo();

                aRoomInfo.FromTime =Reader["FromTime"].ToString();
                aRoomInfo.ToTime= Reader["ToTime"].ToString();

                rooms.Add(aRoomInfo);
            }

            Reader.Close();
            Connection.Close();

            return rooms;
        }


        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            Query = "SELECT * FROM Department";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            

            while (Reader.Read())
            {
                Department aDepartment = new Department();

                aDepartment.Id = Convert.ToInt32(Reader["Id"]);
                aDepartment.DepartmentName = Reader["Department"].ToString();
                
                departments.Add(aDepartment);
            }

            Reader.Close();
            Connection.Close();

            return departments;
            
        }

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courses = new List<Course>();

            Query = "SELECT * FROM Courses WHERE DepartmentId ="+departmentId+"";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                Course aCourse = new Course();

                aCourse.Id = Convert.ToInt32(Reader["Id"]);
                aCourse.Name = Reader["Name"].ToString();

                courses.Add(aCourse);
            }

            Reader.Close();
            Connection.Close();

            return courses;

        }

        public List<RoomInfo> GetAllRooms()
        {
            List<RoomInfo> roomInfo = new List<RoomInfo>();

            Query = "SELECT * FROM RoomDetails";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                RoomInfo aRoomInfo = new RoomInfo();

                aRoomInfo.RoomId = Convert.ToInt32(Reader["Id"]);
                aRoomInfo.RoomName = Reader["Room"].ToString();
                roomInfo.Add(aRoomInfo);
            }

            Reader.Close();
            Connection.Close();

            return roomInfo;

        }

        public List<RoomInfo> GetAllDays()
        {
            List<RoomInfo> roomInfo = new List<RoomInfo>();

            Query = "SELECT * FROM DayInfo";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                RoomInfo aRoomInfo = new RoomInfo();

                aRoomInfo.DayId = Convert.ToInt32(Reader["Id"]);
                aRoomInfo.DayName = Reader["DayName"].ToString();
                roomInfo.Add(aRoomInfo);
            }

            Reader.Close();
            Connection.Close();

            return roomInfo;

        }

        public List<RoomScheduleViewModel> ViewRoomSchedule(int departmentId)
        {
            List<RoomScheduleViewModel> roomSchedules = new List<RoomScheduleViewModel>();

            Query = "SELECT * FROM Courses WHERE DepartmentId = '" + departmentId + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                RoomScheduleViewModel aRoomInfo = new RoomScheduleViewModel();

                aRoomInfo.CourseId = Convert.ToInt32(Reader["Id"]);
                aRoomInfo.CourseCode = Reader["Code"].ToString();
                aRoomInfo.CourseName = Reader["Name"].ToString();
                
                roomSchedules.Add(aRoomInfo);
            }

            Reader.Close();
            Connection.Close();

            return roomSchedules;
        }

        public string GetRoomDescription(int courseId)
        {
            string roomDescription = null;

            Query = "SELECT * FROM AssignedRoom WHERE CourseId ='"+courseId+"'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            
            while (Reader.Read())
            {
                string room = null;
                string day = null;
                string fromTime = null;
                string toTime = null;

                if (Reader["AssignFlag"] == DBNull.Value)
                {
                    continue;
                }

                else if (Convert.ToInt32(Reader["AssignFlag"]) == 0)
                {
                    continue;
                }

                if (Reader["RoomName"] != DBNull.Value)
                {
                    room = Reader["RoomName"].ToString();
                }

                if (Reader["Day"] != DBNull.Value)
                {
                    day = Reader["Day"].ToString();
                }

                if (Reader["FromTime"] != DBNull.Value)
                {
                    fromTime = Reader["FromTime"].ToString();
                }

                if (Reader["ToTime"] != DBNull.Value)
                {
                    toTime = Reader["ToTime"].ToString();
                }
                
                if(room == null && day == null && fromTime == null && toTime==null)
                {
                    continue;
                }

                roomDescription += room + ", " + day + ", " + fromTime + " - " + toTime+"<br/>";
            }

            Reader.Close();
            Connection.Close();

            return roomDescription;
        }
    }
}