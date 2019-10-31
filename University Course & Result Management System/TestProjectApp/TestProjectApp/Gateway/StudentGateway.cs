using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProjectApp.Models;

namespace TestProjectApp.Gateway
{
    public class StudentGateway : Gateway
    {
        public int SaveStudent(Student student)
        {
            var year = DateTime.Now.Year;

            student.RegNo = GetRegistrationNumber(student);

            Reader.Close();
            Connection.Close();

            Query = "INSERT INTO Students VALUES(@name,@regNo,@email,@contactNo,@date,@address,@departmentId, '"+year+"')";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = student.Name;


            Command.Parameters.Add("regNo", SqlDbType.VarChar);
            Command.Parameters["regNo"].Value = student.RegNo;


            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Email;

            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = student.ContactNo;

            Command.Parameters.Add("date", SqlDbType.DateTime);
            Command.Parameters["date"].Value = student.Date;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = student.Address;

            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = student.DepartmentId;



            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }


        public bool IsStudentAssigned(EnrollCourses anEnrollCourse)
        {
            Query = "SELECT * FROM EnrollCourses WHERE StudentId = '"+anEnrollCourse.StudentId+"' AND CourseId = '"+anEnrollCourse.CourseId+"' AND AssignFlag = '1'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.HasRows)
            {
                hasRows = true;
            }

            Reader.Close();
            Connection.Close();
            return hasRows;

        }


        public bool IsEmailExists(string email)
        {

            Query = "SELECT * FROM Students WHERE Email= @email";

            Command = new SqlCommand(Query, Connection);


            Command.Parameters.Clear();

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.HasRows)
            {
                hasRows = true;
            }

            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public string GetDepartmentCode(int departmentId)
        {
            Query = "SELECT * FROM Department WHERE Id=@departmentId";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("departmentId", SqlDbType.VarChar);
            Command.Parameters["departmentId"].Value = departmentId;

            Connection.Open();

            Reader = Command.ExecuteReader();

            string departmentCode = null;

            while (Reader.Read())
            {
                departmentCode = Reader["Code"].ToString();
            }

            Reader.Close();
            Connection.Close();
            return departmentCode;
        }

        public string GetRegistrationNumber(Student student)
        {
            var year = DateTime.Now.Year;

            Query = "SELECT COUNT(DepartmentId) AS Total FROM Students WHERE DepartmentId ='" + student.DepartmentId + "' AND Year = '"+year+"'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            int count = 1;

            while (Reader.Read())
            {
                if (Reader["Total"] == DBNull.Value)
                {
                    count += 0;
                }

                else
                {
                    count += Convert.ToInt32(Reader["Total"]);
                }
            }

            Reader.Close();
            Connection.Close();

            string totalNumber = count.ToString("000");

            string registrationNumber = GetDepartmentCode(student.DepartmentId) + "-2016-" + totalNumber;

            return registrationNumber;
        }


        public List<Student> GetAllStudent()
        {
            Query = "SELECT * FROM Students";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Student> students = new List<Student>();

            while(Reader.Read())
            {
                Student student = new Student();
                student.Id = (int)Reader["Id"];
                student.RegNo = Reader["RegNo"].ToString();
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.ContactNo = Reader["ContactNo"].ToString();
                student.Date = Convert.ToDateTime(Reader["Date"]);
                student.Address = Reader["Address"].ToString();
                student.DepartmentId = (int)Reader["DepartmentId"];

                students.Add(student);
            }
            return students;
        }
        public StudentVM GetStudentWithDepartment(int id)
        {
            Query = "SELECT * FROM StudentInformationWithDepartment WHERE Id=@id";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            

            StudentVM student= new StudentVM();
            Connection.Open();


            Reader = Command.ExecuteReader();

           

            while(Reader.Read())
            {
                student.Id = Convert.ToInt32(Reader["Id"]);
                student.RegNo = Reader["RegNo"].ToString();
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.DepartmentName = Reader["Department"].ToString();
                student.DepartmentId = (int)Reader["DepartmentId"];
            }

            Reader.Close();
            Connection.Close();
            return student;
        }

        public int EnrollCourseSave(EnrollCourses enroll)
        {
            Query = "INSERT INTO EnrollCourses VALUES(@studentId,@courseId,@enrollDate,'1')";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("studentId", SqlDbType.Int);
            Command.Parameters["studentId"].Value =enroll.StudentId;

            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = enroll.CourseId;

            Command.Parameters.Add("enrollDate", SqlDbType.DateTime);
            Command.Parameters["enrollDate"].Value = enroll.EnrollDate;




            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<StudentCourse> GetCoursesTakenByStudentById(int id)
        {
            Query = @"SELECT  DISTINCT c.Id,c.Code,c.Name,c.Credit,c.Description,c.DepartmentId,c.SemesterId FROM Courses c INNER JOIN EnrollCourses r ON (c.Id=r.CourseId) WHERE r.StudentId ='"+id+"' AND r.AssignFlag = 1";


            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<StudentCourse> studentCourses = new List<StudentCourse>();

            while(Reader.Read())
            {
                StudentCourse studentCourse = new StudentCourse();

                studentCourse.Id = (int)Reader["Id"];
                studentCourse.Code = Reader["Code"].ToString();
                studentCourse.Name = Reader["Name"].ToString();
                studentCourse.Credit = Convert.ToDecimal(Reader["Credit"]);
                studentCourse.Description = Reader["Description"].ToString();
                studentCourse.DepartmentId = (int)Reader["DepartmentId"];
                studentCourse.SemesterId = (int)Reader["SemesterId"];
                //studentCourse.AssignFlag = (int)Reader["AssignFlag"];

                studentCourses.Add(studentCourse);
            }

            Reader.Close();
            Connection.Close();
            return studentCourses;
        }

        public int SaveStudentResult(StudentResult studentResult)
        {
            Query = "INSERT INTO StudentResults VALUES(@studentId,@courseId,@gradeLetter)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("studentId", SqlDbType.Int);
            Command.Parameters["studentId"].Value = studentResult.StudentId;

            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = studentResult.CourseId;

            Command.Parameters.Add("gradeLetter", SqlDbType.VarChar);
            Command.Parameters["gradeLetter"].Value = studentResult.GradeLetter;


            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;

        }

       public Boolean IsGradeExistsByStudentId(StudentResult studentResult)
        {
            Query = "SELECT * FROM StudentResults WHERE StudentId='" + studentResult.StudentId + "' AND CourseId='"+studentResult.CourseId+"' ";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.HasRows)
            {
                hasRows = true;
            }

            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public int UpdateStudentResult(StudentResult studentResult)
       {
           Query = "UPDATE StudentResults SET GradeLetter='" + studentResult.GradeLetter + "' WHERE StudentId='" + studentResult.StudentId + "' AND CourseId='" + studentResult.CourseId + "' ";

           Command = new SqlCommand(Query, Connection);

           Connection.Open();

           int rowAffected = Command.ExecuteNonQuery();

           Connection.Close();

           return rowAffected;

       }

        public List<StudentResultView> GetStudentResultViewByStudentId(int studentId)
        {
            Query = " select * From GetstudentResult where StudentId='"+studentId+"'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<StudentResultView> resultViews = new List<StudentResultView>();

            while(Reader.Read())
            {
                StudentResultView resultView = new StudentResultView();

                //resultView.Id = (int)Reader["Id"];
                //resultView.CourseId = (int)Reader["CourseId"];
                resultView.StudentId = (int)Reader["studentId"];
                resultView.Code = Reader["Code"].ToString();
                resultView.Name = Reader["Name"].ToString();
                resultView.Grade = Reader["Grade"].ToString();

                resultViews.Add(resultView);
            }
            Reader.Close();
            Connection.Close();
            return resultViews;

        }

        public Student GetStudentInfo()
        {
            Student aStudent = new Student();

            Query = "SELECT * FROM Students";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                aStudent.Name = Reader["Name"].ToString();
                aStudent.RegNo = Reader["RegNo"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.ContactNo = Reader["ContactNo"].ToString();
                aStudent.Date = Convert.ToDateTime(Reader["Date"]);
                aStudent.Address = Reader["Address"].ToString();
                aStudent.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);

            }

            Reader.Close();
            Connection.Close();

            return aStudent;
        }
    }
}