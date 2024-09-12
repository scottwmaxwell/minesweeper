using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    public class GameboardController : Controller
    {
        GameService gameService = new GameService(new int[] { 12, 12 }, 10);
        public IActionResult Index()
        {
            return View(gameService.Board);
        }

        public IActionResult HandleButtonClick(int Id) 
        {
            gameService.UpdateGame(Id);
            return View("Index", gameService.Board);
        }

<<<<<<< HEAD
        [HttpPost]
        public IActionResult HandleLeftClick(int Id)
=======
        // Left here in case we need it for right-click
        public IActionResult ShowOneCell(int Id) 
>>>>>>> 55778e97e5f3848ca78922f37b09a4800d8e6d85
        {
            gameService.UpdateGame(Id);

<<<<<<< HEAD
            // TODO: Implement GetJsonBoard()
           
            return Json(gameService.GetJsonBoard());
        }
=======
                // Recursive function
                BOARD.FloodFill(row, col);
>>>>>>> 55778e97e5f3848ca78922f37b09a4800d8e6d85

        public IActionResult ShowOneCell(int Id)
        {
            gameService.UpdateGame(Id);
            return PartialView(gameService.Board.FindCellById(Id));
        }

        public IActionResult UpdateBoard(int Id)
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

            return PartialView(BOARD);
        }
    }
}
