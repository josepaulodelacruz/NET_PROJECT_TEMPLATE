using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Diagnostics;


namespace TestProjectRazor.Services
{
    public class DatabaseService
    {
        private SqlConnectionStringBuilder _builder;

        public DatabaseService()
        {
            _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = "";
            _builder.UserID = "";
            _builder.Password = "";
            _builder.InitialCatalog = "";
        }

        public DataTable Query(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(_builder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryString, connection))
                {
                    SqlDataAdapter myda = new SqlDataAdapter(cmd);
                    DataTable result = new DataTable();

                    myda.Fill(result);

                    return result;
                }
            }
        }
    }
}
