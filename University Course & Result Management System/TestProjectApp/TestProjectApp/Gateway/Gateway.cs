using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TestProjectApp.Gateway
{
    public class Gateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public string Query { get; set; }
        public SqlDataReader Reader { get; set; }


        private string connectionString = WebConfigurationManager.ConnectionStrings["TestProjectDBConnection"].ConnectionString;

        public Gateway()
        {
            Connection = new SqlConnection(connectionString);
        }

    }
}