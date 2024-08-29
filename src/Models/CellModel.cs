namespace Minesweeper.Models
{
    public class CellModel
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }
        public int LiveNeighbors { get; set; }

        public CellModel(int id, int row, int column, bool visited, bool live, int liveNeighbors)
        {
            Id = id;
            Row = row;
            Column = column;
            Visited = visited;
            Live = live;
            LiveNeighbors = liveNeighbors;
        }
    }
}
