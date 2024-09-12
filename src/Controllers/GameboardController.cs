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

        [HttpPost]
        public IActionResult HandleLeftClick(int Id)
        {
            gameService.UpdateGame(Id);

            // TODO: Implement GetJsonBoard()
           
            return Json(gameService.GetJsonBoard());
        }

        public IActionResult ShowOneCell(int Id)
        {
            gameService.UpdateGame(Id);
            return PartialView(gameService.Board.FindCellById(Id));
        }
    }
}
