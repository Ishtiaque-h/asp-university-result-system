using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProjectApp.Models;

namespace TestProjectApp.Gateway
{
    public class ViewStatisticsGateway:Gateway
    {
        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = (int)Reader["Id"];
                aDepartment.DepartmentName = Reader["Department"].ToString();

                departments.Add(aDepartment);

            }
            Reader.Close();
            Connection.Close();

            return departments;
        }

        public List<CourseStatisticsViewModel> GetAllInformation(int departmentId)
        {
            Query = "SELECT * FROM CourseAssigned WHERE DepartmentId='"+departmentId+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseStatisticsViewModel> aCourseStatisticsViewModelscourses = new List<CourseStatisticsViewModel>();
            while (Reader.Read())
            {
                CourseStatisticsViewModel aCourse = new CourseStatisticsViewModel();
                aCourse.CourseCode = Reader["Code"].ToString();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.SemesterName = Reader["Semester"].ToString();

                if (Reader["AssignFlag"] == DBNull.Value || Convert.ToInt32(Reader["AssignFlag"]) == 0)
                {
                    aCourse.AssignedTo = "Not Assigned yet";
                }

                else
                {
                    aCourse.AssignedTo = Reader["AssignTo"].ToString();
                }

                aCourseStatisticsViewModelscourses.Add(aCourse);

            }
            Reader.Close();
            Connection.Close();

            return aCourseStatisticsViewModelscourses;
        }
    }
}