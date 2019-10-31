using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProjectApp.Models;

namespace TestProjectApp.Gateway
{
    public class CourseAssignedToTeacherGateway : Gateway
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
                aDepartment.Code = Reader["Code"].ToString();
                aDepartment.DepartmentName = Reader["Department"].ToString();

                departments.Add(aDepartment);

            }
            Reader.Close();
            Connection.Close();

            return departments;
        }

        public int SaveCourseAssigned(CourseAssignedToTeacher aCourseAssignedToTeacher)
        {

            Query = "INSERT INTO TeacherAssignedToCourse(DepartmentId,TeacherId,CourseId,AssignFlag) Values ('" +
                    aCourseAssignedToTeacher.DepartmentId + "', " + aCourseAssignedToTeacher.TeacherId + ", " +
                    aCourseAssignedToTeacher.CourseId + ", '" + 1 + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int result = Command.ExecuteNonQuery();
            Connection.Close();

            result = UpdateCourseAssigned(aCourseAssignedToTeacher);

            return result;
        }

        public bool IsCourseAssigned(CourseAssignedToTeacher aCourseToTeacher)
        {
            Query = "SELECT * FROM TeacherAssignedToCourse WHERE CourseId='" + aCourseToTeacher.CourseId + "' AND AssignFlag ='1'";

            Command = new SqlCommand(Query, Connection);
            
            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasCourse = false;

            if (Reader.HasRows)
            {
                hasCourse = true;
            }

            Reader.Close();
            Connection.Close();

            return hasCourse;

        }


        public int UpdateCourseAssigned(CourseAssignedToTeacher aCourseAssignedToTeacher)
        {

            Query = "UPDATE Teacher SET RemainingCredit=(SELECT RemainingCredit FROM Teacher WHERE Id='" + aCourseAssignedToTeacher.TeacherId + "')-(SELECT Credit FROM Courses WHERE Id='" +
                       aCourseAssignedToTeacher.CourseId + "') WHERE Id='" + aCourseAssignedToTeacher.TeacherId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int result = Command.ExecuteNonQuery();
            Connection.Close();
            return result;
        }

        public List<Teacher> GetTeachers()
        {

            Query = "SELECT Id,DepartmentId,Name FROM Teacher";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = (int)Reader["Id"];
                teacher.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                teacher.Name = Reader["Name"].ToString();
                teachers.Add(teacher);

            }
            Reader.Close();
            Connection.Close();

            return teachers;
        }

        public List<Course> GetAllUnAssignedCourses(int departmentId)
        {
            Query = "SELECT Id,Code,Name FROM Courses WHERE DepartmentId='"+departmentId+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = (int)Reader["Id"];
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();

            return courses;
        }

        public Course GetCourseDetails(int courseId)
        {
            Query = "SELECT Id,Name,Credit FROM Courses WHERE Id='"+courseId+"' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Course aCourse = new Course();
            if (Reader.Read())
            {

                aCourse.Id = (int)Reader["Id"];
                aCourse.Name = Reader["Name"].ToString();
                aCourse.Credit = (decimal)Reader["Credit"];
            }
            Reader.Close();
            Connection.Close();

            return aCourse;
        }

        public Teacher GetTeacherDetails(int teacherId)
        {
            Query = "SELECT CreditTaken,RemainingCredit FROM Teacher WHERE Id='" + teacherId + "' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Teacher aTeacher = new Teacher();
            
            while (Reader.Read())
            {

                aTeacher.CreditTaken = (decimal)Reader["CreditTaken"];
                aTeacher.RemainingCrdeit =(decimal) Reader["RemainingCredit"];
            }
            Reader.Close();
            Connection.Close();

            return aTeacher;
        }
    }
}