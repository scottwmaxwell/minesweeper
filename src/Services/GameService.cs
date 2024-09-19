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
            this.SetGame();
        }

        public void SetGame()
        {
            // Reset grid
            Board = new BoardModel(GridSize);

            // Set game status
            this.GameStatus = 0;

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
            // Check if the cell is flagged before processing the click
            if (cell.Flagged || this.GameStatus > 0)
            {
                // Do not update the cell if it is flagged
                return;
            }
            
            if (!cell.Visited)
            {
                int row = cell.Row;
                int col = cell.Column;

                // Recursive function
                Board.FloodFill(row, col);

                // Update cell
                cell.Visited = true;
            }

            if (cell.Live)
            {
                this.GameStatus = 2;
            }
            else if (!Board.CheckUnivisted())
            {
                this.GameStatus = 1;
            }
        }

        public void FlagCell(int id)
        {
            CellModel cell = Board.FindCellById(id);
            if (!cell.Visited)
            {
                if(!cell.Flagged)
                {
                    // Flag cell
                    cell.Flagged = true;
                }
                else
                {
                    cell.Flagged = false;
                }
                
            }

        }

        public Boolean SaveGame(int id)
        {
            Boolean result = false;
            GameDAO gameDAO = new GameDAO();
            result = gameDAO.SaveGame(this, id);
            return result;
        }

        public Boolean LoadGame(string id)
        {
            Boolean result = false;
            GameDAO gameDAO = new GameDAO();
            SavedGame savedGame = gameDAO.GetGame(id);
            if(savedGame != null)
                result = true;
            Board = savedGame.Board;
            GameStatus = 0;
            return result;
        }

    }
}
