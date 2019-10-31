using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProjectApp.Gateway;
using TestProjectApp.Models;

namespace TestProjectApp.Manager
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway = new TeacherGateway();
        public string SaveTeacher(Teacher teacher)
        {
            bool hasEmail = teacherGateway.IsEmailExists(teacher.Email);

            if (hasEmail)
            {
                return "There is already a teacher with this email";
            }

            else
            {
                int row = teacherGateway.SaveTeacher(teacher);

                if (row > 0)
                {
                    return "Teacher information saved Succefully";
                }
                else
                {
                    return "An error occured";
                }

            }
        }

        public List<Designation> GetAllDesignation()
        {
            return teacherGateway.GetAllDesignation();
        }
    }
}