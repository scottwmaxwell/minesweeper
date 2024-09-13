using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    public class GameboardController : Controller
    {
        private readonly GameService gameService;

        // Initialize service when gameboard is created
        public GameboardController(GameService gameService)
        {
            this.gameService = gameService;
        }

        public IActionResult Index()
        {
            this.gameService.SetGame();
            return View(gameService.Board);
        }

        public IActionResult HandleButtonClick(int Id)
        {
            gameService.UpdateGame(Id);
            return View("Index", gameService.Board);
        }

        public IActionResult UpdateBoard(int Id)
        {
            gameService.UpdateGame(Id);
            ViewBag.gameStatus = gameService.GameStatus;
            return PartialView(gameService.Board);
        }

        public IActionResult UpdateStatus()
        {
            return Json(gameService.GameStatus);
        }

        public IActionResult FlagCell(int Id)
        {
            gameService.FlagCell(Id);
            return PartialView("UpdateBoard", gameService.Board);
        }
    }
}
