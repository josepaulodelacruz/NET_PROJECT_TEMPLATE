using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        Task<User> UpdateUser(IConfiguration config, User user, int id);

        Task<int> DeleteUserById(IConfiguration config, int id);
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

            try
            {
                using (SqlConnection conn = new SqlConnection(config.GetConnectionString("Development")))
                {
                    conn.Open();

                    string query = "INSERT INTO [USER]" +
                        "([Email], [Name])" +
                        "VALUES" +
                        "(@Email, @Name)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Name", user.Name);

                        int result = cmd.ExecuteNonQuery();

                        Debug.WriteLine("Inserting to table...");
                        Debug.WriteLine(result);
                    }

                };

                return user;
            }
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return new User();
            }
        }

        public async Task<User> UpdateUser(IConfiguration config, User updatedUser, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(config.GetConnectionString("Development")))
                {
                    conn.Open();

                    string query = "UPDATE [USER] SET [Email] = @Email, [Name] = @Name WHERE ID = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Email", updatedUser.Email);
                        cmd.Parameters.AddWithValue("@Name", updatedUser.Name);

                        int result = cmd.ExecuteNonQuery();

                        Debug.WriteLine("Show result query");
                        Debug.WriteLine(result);

                        if(result == 0)
                        {
                            return new User();
                        }
                    }

                }

                updatedUser.ID = id;

                return updatedUser;
            }
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return new User();
            }

        }
        public async Task<int> DeleteUserById(IConfiguration config, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(config.GetConnectionString("Development")))
                {
                    conn.Open();

                    string query = "DELETE FROM [USER] WHERE ID = @Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        int result = cmd.ExecuteNonQuery();

                        return result;
                    }
                }

            }
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0; // failed
            }

        }

    }
}
