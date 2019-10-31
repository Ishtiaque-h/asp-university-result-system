using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProjectApp.Gateway;

namespace TestProjectApp.Manager
{
    public class UnassignCoursesManager
    {
        public string UnassignCourses()
        {
            UnassignCoursesGateway aUnassignCoursesGateway=new UnassignCoursesGateway();
            return aUnassignCoursesGateway.UnassingCourses();
        }
    }
}