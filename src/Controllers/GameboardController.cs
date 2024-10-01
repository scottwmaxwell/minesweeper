using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using Minesweeper.Utility;

namespace Minesweeper.Controllers
{
    public class GameboardController : Controller
    {
        private readonly GameService gameService;
        private readonly Ilogger logger;

        // Initialize service when gameboard is created
        public GameboardController(GameService gameService, Ilogger logger)
        {
            this.gameService = gameService;
            this.logger = logger;
        }

        [HttpGet]
        [CustomAuthorization]
        public IActionResult Index()
        {
            Console.WriteLine("Index");
            logger.Info("Loading the Gameboard Index page.");
            this.gameService.SetGame();
            return View(gameService.Board);
        }

        public IActionResult HandleButtonClick(int Id)
        {
            logger.Info("Board cell " + Id + " was clicked.");
            this.gameService.SetGame();
            gameService.UpdateGame(Id);
            return View("Index", gameService.Board);
        }

        public IActionResult UpdateBoard(int Id)
        {
            logger.Info("Updating board because cell " + Id + " was changed.");
            gameService.UpdateGame(Id);
            ViewBag.gameStatus = gameService.GameStatus;
            return PartialView(gameService.Board);
        }

        public IActionResult UpdateStatus()
        {
            logger.Info("Updating game status.");
            return Json(gameService.GameStatus);
        }

        public IActionResult FlagCell(int Id)
        {
            logger.Info("Flagging cell " + Id + " .");
            gameService.FlagCell(Id);
            return PartialView("UpdateBoard", gameService.Board);
        }

        public IActionResult SaveGame()
        {
            logger.Info("Saving game.");
            int userId = int.Parse(HttpContext.Session.GetString("id"));
            gameService.SaveGame(userId);
            return Json("Game saved");
        }

        public IActionResult LoadSavedGame(string id)
        {
            logger.Info("Loading game.");
            gameService.LoadGame(id);
            return PartialView("UpdateBoard", gameService.Board);
        }
    }
}
