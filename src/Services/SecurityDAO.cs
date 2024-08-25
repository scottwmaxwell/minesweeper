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
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 255).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 255).Value = user.Password;

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

        public bool addUser(UserModel user)
        {
            bool success = false;
            string sqlStatement = "INSERT INTO dbo.users (USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, SEX, AGE, STATE) VALUES (@username, @password, @firstname, @lastname, @email, @sex, @age, @state)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 255).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 255).Value = user.Password;
                command.Parameters.Add("@firstname", System.Data.SqlDbType.VarChar, 255).Value = user.FirstName;
                command.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 255).Value = user.LastName;
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 255).Value = user.Email;
                command.Parameters.Add("@sex", System.Data.SqlDbType.VarChar, 255).Value = user.Sex;
                command.Parameters.Add("@age", System.Data.SqlDbType.VarChar, 255).Value = user.Age;
                command.Parameters.Add("@state", System.Data.SqlDbType.VarChar, 255).Value = user.State;

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Added User");
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }
    }
}
