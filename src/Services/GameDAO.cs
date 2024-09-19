using Minesweeper.Models;
using System.Data.SqlClient;
using System.Text.Json;

namespace Minesweeper.Services
{
    public class GameDAO
    {

        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=minesweeper;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public bool SaveGame(GameService game, int id)
        {

            DateTime time = DateTime.Now;
            string sqlStatement = "INSERT INTO dbo.games (userId, date, game) VALUES (@userId, @date, @game)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = id;
                command.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value = time;
                command.Parameters.Add("@game", System.Data.SqlDbType.VarChar).Value = JsonSerializer.Serialize(game.Board);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Added Game");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
        }

        public List<SavedGame> GetAllGames(string userId)
        {

            List<SavedGame> savedGames = new List<SavedGame>();

            string sqlStatement = "SELECT id, userId, date, game FROM dbo.games WHERE userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@userId", System.Data.SqlDbType.VarChar, 255).Value = userId;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {                       
                        SavedGame savedGame = new SavedGame
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Date = reader.GetDateTime(2),
                            Board = JsonSerializer.Deserialize<BoardModel>(reader.GetString(3))
                        };

                        savedGames.Add(savedGame);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return savedGames ?? new List<SavedGame>();
        }

        public SavedGame GetGame(string id = null)
        {

            SavedGame savedGame = null;
            string sqlStatement = "SELECT id, userId, date, game FROM dbo.games WHERE id = @id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar, 255).Value = id;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(3));
                        savedGame = new SavedGame
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Date = reader.GetDateTime(2),
                            Board = JsonSerializer.Deserialize<BoardModel>(reader.GetString(3))
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return savedGame ?? new SavedGame();
        }

        public bool DeleteGame(string id)
        {
            bool successful = false;
            string sqlStatement = "DELETE FROM dbo.games WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar, 255).Value = id;

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Deleted Game");
                        successful = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return successful;
        }
    }
}