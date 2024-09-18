namespace Minesweeper.Models
{
    public class SavedGame
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SerializedGame { get; set; }

        public SavedGame(int id, int userId, string serializedGame) 
        {
            this.Id = id;
            this.UserId = userId;
            this.SerializedGame = serializedGame;
        }
    }
}
