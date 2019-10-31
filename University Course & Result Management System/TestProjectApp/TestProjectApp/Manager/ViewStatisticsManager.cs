using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProjectApp.Gateway;
using TestProjectApp.Models;

namespace TestProjectApp.Manager
{
    public class ViewStatisticsManager
    {

        ViewStatisticsGateway aViewStatisticsGateway = new ViewStatisticsGateway();
        public List<Department> GetAllDepartments()
        {
            
            return aViewStatisticsGateway.GetAllDepartments();
        }


        public List<CourseStatisticsViewModel> GetAllInformation(int departmentId)
        {
            return aViewStatisticsGateway.GetAllInformation(departmentId);
        }
    }
}