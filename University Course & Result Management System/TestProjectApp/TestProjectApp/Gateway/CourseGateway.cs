using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProjectApp.Models;


namespace TestProjectApp.Gateway
{
    public class CourseGateway:Gateway
    {
        public int SaveCourse(Course course)
        {
            Query = "INSERT INTO Courses VALUES(@code,@name,@credit,@description,@departmentId,@semesterId)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = course.Code;

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = course.Name;

            Command.Parameters.Add("credit", SqlDbType.Int);
            Command.Parameters["credit"].Value = course.Credit;

            Command.Parameters.Add("description", SqlDbType.VarChar);
            Command.Parameters["description"].Value = course.Description;

            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = course.DepartmentId;

            Command.Parameters.Add("semesterId", SqlDbType.Int);
            Command.Parameters["semesterId"].Value = course.SemesterId;


            Connection.Open();

            

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<Semester> GetAllSemester()
        {
            Query = "SELECT * FROM Semester";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Semester> semesters = new List<Semester>();

            while (Reader.Read())
            {
                Semester semester = new Semester();
                semester.Id = (int)Reader["Id"];
                semester.SemesterName = Reader["Semester"].ToString();


                semesters.Add(semester);
            }
            Reader.Close();
            Connection.Close();

            return semesters;
        }

        public bool IsCodeExists(Course aCourse) {

            Query = "SELECT * FROM Courses WHERE Code = @code";

            Command = new SqlCommand(Query, Connection);


            Command.Parameters.Clear();

            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = aCourse.Code;


            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isCodeExists = false;

            if (Reader.HasRows)
            {
                isCodeExists = true;
            }

            Reader.Close();
            Connection.Close();

            return isCodeExists;
        }



        public bool IsNameExists(Course aCourse)
        {

            Query = "SELECT * FROM Courses WHERE Name = @name AND DepartmentId = '"+aCourse.DepartmentId+"'";

            Command = new SqlCommand(Query, Connection);


            Command.Parameters.Clear();

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aCourse.Name;


            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isNameExists = false;

            if (Reader.HasRows)
            {
                isNameExists = true;
            }

            Reader.Close();
            Connection.Close();

            return isNameExists;
        }

        public List<Course> GetAllCourse()
        {
            Query = "SELECT * FROM Courses";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Course> courses = new List<Course>();

            while(Reader.Read())
            {
                Course course = new Course();
                
                
                    course.Id = Convert.ToInt32(Reader["Id"]);
                    course.Code = Reader["Code"].ToString();
                    course.Name = Reader["Name"].ToString();
                   course. Credit = Convert.ToDecimal(Reader["Credit"]);
                   course.Description = Reader["Description"].ToString();
                    course.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                    course.SemesterId = Convert.ToInt32(Reader["SemesterId"]);          


                courses.Add(course);
            }
            Reader.Close();

            Connection.Close();

            return courses;

        }

    }
}