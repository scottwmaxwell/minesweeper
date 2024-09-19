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

        [HttpGet]
        [CustomAuthorization]
        public IActionResult Index()
        {
            Console.WriteLine("Index");
            this.gameService.SetGame();
            return View(gameService.Board);
        }

        public IActionResult HandleButtonClick(int Id)
        {
            this.gameService.SetGame();
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

        public IActionResult SaveGame()
        {
            int userId = int.Parse(HttpContext.Session.GetString("id"));
            gameService.SaveGame(userId);
            return Json("Game saved");
        }
    }
}
