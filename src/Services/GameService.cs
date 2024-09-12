using Minesweeper.Models;

namespace Minesweeper.Services
{
    public class GameService
    {
        public BoardModel Board { get; set; }
        public int[] GridSize { get; set; }
        public int LiveNeighbors { get; set; }
        public int GameStatus { get; set; } // 0 = in progress, 1 = won, 2 = lose

        public GameService(int[] gridSize, int liveNeighbors)
        {
            GridSize = gridSize;
            LiveNeighbors = liveNeighbors;
            Board = new BoardModel(gridSize);
            this.SetGame();
        }

        public void SetGame()
        {
            Board.SetupLiveNeighbors(LiveNeighbors);

            // Calculate the cell live neighbors
            for (int i = 0; i < GridSize[0]; i++)
            {
                for (int j = 0; j < GridSize[1]; j++)
                {
                    Board.CalculateLiveNeighbors(i, j);
                }
            }
        }

        public void UpdateGame(int id)
        {
            CellModel cell = Board.FindCellById(id);
            if (!cell.Visited)
            {
                int row = cell.Row;
                int col = cell.Column;

                // Recursive function
                Board.FloodFill(row, col);

                // Update cell
                cell.Visited = true;
            }
        }

        public JsonContent GetJsonBoard()
        {
            // TODO: create a json object by parsing Board.Grid
            return null;
        }

    }
}
