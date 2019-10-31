using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProjectApp.Gateway;
using TestProjectApp.Models;

namespace TestProjectApp.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public Student GetStudentInfo()
        {
            Student aStudent = new Student();

            aStudent = studentGateway.GetStudentInfo();

            List<Department> departments = new List<Department>();

            departments = aDepartmentGateway.GetAllDepartment();


            foreach (Department aDepartment in departments)
            {
                if (aDepartment.Id == aStudent.DepartmentId)
                {
                    aStudent.DepartmentName = aDepartment.DepartmentName;
                }
            }


            return aStudent;
        }


        public string SaveStudent(Student student)
        {
            bool hasRows = studentGateway.IsEmailExists(student.Email);
            {
                if (!hasRows)
                {
                    int row = studentGateway.SaveStudent(student);
                    if (row > 0)
                    {
                        return "Student information has been Successfully";
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {

                    return "Email exists already";
                }
            }
        }
        public List<Student> GetAllStudent()
        {
            return studentGateway.GetAllStudent();
        }
        public StudentVM GetStudentWithDepartment(int id)
        {
            return studentGateway.GetStudentWithDepartment(id);
        }

        public string EnrollCourseSave(EnrollCourses enroll)
        {
            bool isStudentAssigned = studentGateway.IsStudentAssigned(enroll);

            if (isStudentAssigned)
            {
                return "This course has already been assigned to this student";
            }

            else
            {
                int row = studentGateway.EnrollCourseSave(enroll);
                if (row > 0)
                {
                    return "The course has been assigned to the student successfully";
                }
                else
                {
                    return "An error occured";
                }
            }            
        }

        public List<StudentCourse> GetCoursesTakenByStudentById(int id)
        {
            return studentGateway.GetCoursesTakenByStudentById(id);
        }



        public string SaveStudentResult(StudentResult studentResult)
        {
            bool hasExists = studentGateway.IsGradeExistsByStudentId(studentResult);
            if(!hasExists)
            {
                int row = studentGateway.SaveStudentResult(studentResult);
                if(row>0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Failed";
                }
            }
            else
            {
                int row = studentGateway.UpdateStudentResult(studentResult);
                if (row > 0)
                {
                    return "Update Successfully";
                }
                else
                {
                    return "Failed";
                }
            }
            
        }

        public List<StudentResultView> GetStudentResultViewByStudentId(int studentId)
        {
            return studentGateway.GetStudentResultViewByStudentId(studentId);
        }
    }
}