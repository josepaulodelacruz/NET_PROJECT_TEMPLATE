using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProjectRazor.Models;

namespace TestProjectRazor.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get(IConfiguration config);
        Task<User> GetById(IConfiguration config, int id);
        Task<User> AddUser(IConfiguration config, User user);
    }

    public class UserService : IUserService
    {
        public async Task<User> GetById(IConfiguration configuration, int id)
        {
            User user = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("Development")))
                {
                    conn.Open();

                    string query = "SELECT" +
                        "[ID], [Email], [Name]" +
                        "FROM [USER]" +
                        "WHERE [ID] = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while(await reader.ReadAsync())
                            {
                                user.ID = int.Parse(reader["ID"].ToString());
                                user.Email = reader["Email"].ToString();
                                user.Name = reader["Name"].ToString();
                            }

                        }

                    }

                }

                return user;
            } 
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return user;
            }
        }
        //Get All data in the database
        public async Task<IEnumerable<User>> Get(IConfiguration config)
        {
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(config.GetConnectionString("Development")))
                {
                    conn.Open();

                    string query = "SELECT [ID], [Email], [Name]" +
                        "FROM [USER]";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Debug.WriteLine("GET READER");
                                var user = new User()
                                {
                                    ID = int.Parse(reader["ID"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    Name = reader["Name"].ToString(),
                                };

                                users.Add(user);
                            }
                        }
                    }

                }

                return users;

            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return users;
            }

        }

        public async Task<User> AddUser(IConfiguration config, User user)
        {
            return new User()
            {
                Email = "test",
                Name = "John Doe",
            };
        }

    }
}
