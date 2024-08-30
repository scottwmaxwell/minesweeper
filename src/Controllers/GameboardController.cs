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
            BOARD.SetupLiveNeighbors(10);

            // Calculate the cell live neighbors and get non live count
            int nonLive = 0;
            for (int i = 0; i < GRID_SIZE[0]; i++)
            {
                for (int j = 0; j < GRID_SIZE[1]; j++)
                {
                    if (!BOARD.Grid[i, j].Live)
                    {
                        nonLive++;
                    }
                    BOARD.CalculateLiveNeighbors(i, j);
                }
            }

            return View();
        }

        public IActionResult HandleButtonClick(string cellId) 
        {
            // Convert from string to int
            int id = int.Parse(cellId);

            // Update cell
            BOARD.FindCellById(id).Visited = true;

            return View("Index", BOARD);
        }
    }
}
