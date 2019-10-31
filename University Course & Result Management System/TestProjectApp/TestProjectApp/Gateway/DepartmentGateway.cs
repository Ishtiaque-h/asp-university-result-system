using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProjectApp.Models;

namespace TestProjectApp.Gateway
{
    public class DepartmentGateway:Gateway
    {
        public int SaveDepartment(Department department)
        {
            Query = "INSERT INTO Department VALUES(@code,@name)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("code",SqlDbType.VarChar);
            Command.Parameters["Code"].Value = department.Code;

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = department.DepartmentName;
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<Department> GetAllDepartment()
        {
            Query = "SELECT * FROM Department";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Department> departments = new List<Department>();

            while(Reader.Read())
            {
                Department department = new Department();
                department.Id = (int)Reader["Id"];
                department.Code = Reader["Code"].ToString();
                department.DepartmentName = Reader["Department"].ToString();

                departments.Add(department);
            }
            Reader.Close();
            Connection.Close();

            return departments;
        }
        public bool IsCodeExists(string code)
        {

            Query = "SELECT * FROM Department WHERE Code= '"+code+"'";

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

        public bool IsNameExists(string departmentName)
        {

            Query = "SELECT * FROM Department WHERE Department = @departmentName";

            Command = new SqlCommand(Query, Connection);


            Command.Parameters.Clear();

            Command.Parameters.Add("departmentName", SqlDbType.VarChar);
            Command.Parameters["departmentName"].Value = departmentName;

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

    }
}