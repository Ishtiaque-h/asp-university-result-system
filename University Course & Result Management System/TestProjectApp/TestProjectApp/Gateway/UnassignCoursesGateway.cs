using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestProjectApp.Gateway
{
    public class UnassignCoursesGateway:Gateway
    {
        public string UnassingCourses()
        {
            Query = "Update EnrollCourses SET AssignFlag=0" + "Update TeacherAssignedToCourse SET AssignFlag='0'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int affectedRows = Command.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                Connection.Close();
                return "All the courses have been unassigned";
            }
            Connection.Close();
            return "An error occured";

        }
    }
}