using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProjectApp.Gateway;
using TestProjectApp.Models;

namespace TestProjectApp.Manager
{
    public class DepartManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();

        public string SaveDepartment(Department department)
        {
            bool hasRows = departmentGateway.IsCodeExists(department.Code);
            bool hasDepartmentName = departmentGateway.IsNameExists(department.DepartmentName);
            
                if (hasRows)
                {
                    return "A department with this code already exists";
                }

                if (hasDepartmentName)
                {
                    return "A department with this name already exists";
                }

                else
                {

                    int row = departmentGateway.SaveDepartment(department);

                    if (row > 0)
                    {
                        return "Department Information Succefully";
                    }
                    else
                    {
                        return "An error occured";
                    }  
                }            
        }

        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartment();
        }
    }
}