using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{
    public class GameboardController : Controller
    {
        private static readonly int[] GRID_SIZE = { 12, 12 };
        private static readonly BoardModel BOARD = new BoardModel(GRID_SIZE);

        public IActionResult Index()
        {
            // Setup the live cells based on the value provided
            BOARD.Reset();
            BOARD.SetupLiveNeighbors(10);

            // Calculate the cell live neighbors
            for (int i = 0; i < GRID_SIZE[0]; i++)
            {
                for (int j = 0; j < GRID_SIZE[1]; j++)
                {
                    BOARD.CalculateLiveNeighbors(i, j);
                }
            }
            return View(BOARD);
        }

        public IActionResult HandleButtonClick(int Id) 
        {
            CellModel cell = BOARD.FindCellById(Id);
            if (!cell.Visited)
            {
                int row = cell.Row;
                int col = cell.Column;

                // Recursive function
                BOARD.FloodFill(row, col);

                // Update cell
                cell.Visited = true;
            }

            return View("Index", BOARD);
        }

        public IActionResult ShowOneCell(int Id) 
        {
            CellModel cell = BOARD.FindCellById(Id);
            if (!cell.Visited)
            {
                int row = cell.Row;
                int col = cell.Column;

                // Recursive function
                // I don't think this works for one cell, might need to implement another method
                // BOARD.FloodFill(row, col);

                // Update cell
                cell.Visited = true;
            }

            return PartialView(BOARD.FindCellById(Id));
        }
    }
}
