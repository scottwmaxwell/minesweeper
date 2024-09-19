using NuGet.Packaging.Signing;

namespace Minesweeper.Models
{
    public class SavedGame
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public BoardModel Board { get; set; }

        public SavedGame(int id, int userId, DateTime date, BoardModel board) 
        {
            this.Id = id;
            this.UserId = userId;
            this.Date = date;
            this.Board = board;
        }

        public SavedGame() { }
    }
}
