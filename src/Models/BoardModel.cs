using System.Drawing;

namespace Minesweeper.Models
{
    public class BoardModel
    {
        public int[] Size { get; set; }
        public CellModel[,] Grid { get; set; }
        public decimal Difficulty { get; set; }

        public BoardModel(int[] size)
        {
            // The array size contains the number of (0) columns and (1) rows
            Size = size;
            Grid = new CellModel[Size[0], Size[1]];
            int id = 1;
            // Insert a cell in each location
            for (int i = 0; i < Size[0]; i++)
            {
                for (int j = 0; j < Size[1]; j++)
                {
                    Grid[i, j] = new CellModel(id, i, j, false, false, 0);
                    id++;
                }
            }
        }

        public void Reset()
        {
            // The array size contains the number of (0) columns and (1) rows
            Grid = new CellModel[Size[0], Size[1]];
            int id = 1;
            // Insert a cell in each location
            for (int i = 0; i < Size[0]; i++)
            {
                for (int j = 0; j < Size[1]; j++)
                {
                    Grid[i, j] = new CellModel(id, i, j, false, false, 0);
                    id++;
                }
            }
        }

        public void SetupLiveNeighbors(decimal difficulty)
        {
            // Get number of live cells using difficulty as a percentage
            Difficulty = difficulty;
            decimal percent = Difficulty / 100;
            decimal liveCells = percent * (Size[0] * Size[1]);
            liveCells = Math.Floor(liveCells);

            // Setup random number to decide if cell should be set to live
            Random rnd = new Random();

            // Loop until all liveCells are set
            for (int mine = 0; mine < liveCells;)
            {
                int col = rnd.Next(0, Size[0]);
                int row = rnd.Next(0, Size[1]);

                if (!Grid[col, row].Live)
                {
                    Grid[col, row].Live = true;
                    mine++;
                }
            }
        }

        public void CalculateLiveNeighbors(int i, int j)
        {
            // Check if cell is live
            if (Grid[i, j].Live)
            {
                Grid[i, j].LiveNeighbors = 9;
            }
            else
            {
                // Traverse the live neighbors and increase count for current cell
                // The below code was acquired from the below link, however it was altered by me to fit my solution
                // Source: https://stackoverflow.com/questions/652106/finding-neighbours-in-a-two-dimensional-array
                int rowLimit = Size[0];
                if (rowLimit > 0)
                {
                    int columnLimit = Size[1];
                    if (columnLimit > 0)
                    {
                        for (int x = Math.Max(0, i - 1); x <= Math.Min(i + 1, rowLimit); x++)
                        {
                            for (int y = Math.Max(0, j - 1); y <= Math.Min(j + 1, columnLimit); y++)
                            {
                                if (x < rowLimit && y < columnLimit && (x != i || y != j))
                                {
                                    if (Grid[x, y].Live)
                                    {
                                        Grid[i, j].LiveNeighbors++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Returns true if there are unvisited cells without a bomb
        public bool CheckUnivisted()
        {
            for (int i = 0; i < Size[0]; i++)
            {
                for (int j = 0; j < Size[1]; j++)
                {
                    if (Grid[i, j].Visited == false && Grid[i, j].Live == false)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void FloodFill(int row, int col)
        {

            // Base case : cell Has live neighbors
            if (Grid[row, col].LiveNeighbors != 0)
            {
                Grid[row, col].Visited = true;
                return;
            }
            else
            {
                // check if cell is flagged
                if (!Grid[row, col].Flagged)
                {
                    // If not flagged, set as visited
                    Grid[row, col].Visited = true;
                }


                // Recursively visit all neighbors (up down left right)
                int[] xCell = { 0, 0, -1, 1, -1, 1, -1, 1 };
                int[] yCell = { 1, -1, 0, 0, -1, 1, 1, -1 };
                int i, next_x, next_y;

                for (i = 0; i < 8; i++)
                {

                    next_x = row + xCell[i];
                    next_y = col + yCell[i];

                    if (next_x < Size[0]
                        && next_y < Size[1]
                        && next_x >= 0
                        && next_y >= 0
                        && Grid[next_x, next_y].Visited == false)
                    {
                        FloodFill(next_x, next_y);
                    }

                }
            }
        }

        // Method to find a cell by its id
        public CellModel FindCellById(int id)
        {
            // Iterate through the grid to find the cell with the matching id
            for (int i = 0; i < Size[0]; i++)
            {
                for (int j = 0; j < Size[1]; j++)
                {
                    if (Grid[i, j].Id == id)
                    {
                        return Grid[i, j];
                    }
                }
            }
            // Return null if not found
            return null;
        }
    }
}
