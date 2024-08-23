using Minesweeper.Models;
using System.Data.SqlClient;

namespace Minesweeper.Services
{
    public class SecurityDAO
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False";


        public bool findUserByNameAndPassword(UserModel user)
        {
            // Assume nothing is found
            bool success = false;

            // uses prepared statements for security. @username @password are defined below
            string sqlStatement = "SELECT * FROM dbo.users WHERE username = @username and password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // define the values of the two placeholders in the sqlSatement string
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 255).Value = user.userName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 255).Value = user.password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return success;
        }
    }
}
