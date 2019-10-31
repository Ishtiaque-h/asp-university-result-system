using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestProjectApp.Models;

namespace TestProjectApp.Gateway
{
    public class TeacherGateway:Gateway
    {
        public int SaveTeacher(Teacher teacher)
        {
            Query = "INSERT INTO Teacher VALUES(@name,@address,@email,@contact,@designationId,@departmentId,@creditTaken,@remainingCredit)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = teacher.Name;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = teacher.Address;

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = teacher.Email;

            Command.Parameters.Add("contact", SqlDbType.VarChar);
            Command.Parameters["contact"].Value = teacher.ContactNo;

            Command.Parameters.Add("designationId", SqlDbType.Int);
            Command.Parameters["designationId"].Value = teacher.DesignatonId;

            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = teacher.DepartmentId;

            Command.Parameters.Add("creditTaken", SqlDbType.Decimal);
            Command.Parameters["creditTaken"].Value = teacher.CreditTaken;

            Command.Parameters.Add("remainingCredit", SqlDbType.Decimal);
            Command.Parameters["remainingCredit"].Value = teacher.RemainingCrdeit;


            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<Designation> GetAllDesignation()
        {
            Query = "SELECT * FROM Designation";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Designation> designations = new List<Designation>();

            while (Reader.Read())
            {
                Designation designation = new Designation();
                designation.Id = (int)Reader["Id"];
                designation.DesignationName = Reader["Designation"].ToString();


                designations.Add(designation);
            }
            Reader.Close();
            Connection.Close();

            return designations;
        }

        public bool IsEmailExists(string email)
        {

            Query = "SELECT * FROM Teacher WHERE Email = @email";

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
    }
}