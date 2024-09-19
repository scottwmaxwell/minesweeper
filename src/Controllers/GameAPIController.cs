using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GameAPIController : ControllerBase
    {
        GameDAO gameDAO = new GameDAO();

        [HttpGet("showSavedGames")]
        public ActionResult <IEnumerable<SavedGame>> ShowSavedGames()
        {
            List<SavedGame> savedGames = null;
            string userId = HttpContext.Session.GetString("id");
            savedGames = gameDAO.GetAllGames(userId);
            return savedGames;
        }

        [HttpGet("showSavedGames/{gameId}")]
        public ActionResult <SavedGame> ShowSavedGame(string gameId)
        {
            SavedGame savedGame = null;
            savedGame = gameDAO.GetGame(gameId);
            return savedGame;
        }

        [HttpDelete("deleteOneGame/{gameId}")]
        public ActionResult DeleteOneGame(string gameId)
        {
            Boolean result = gameDAO.DeleteGame(gameId);

            if (result)
            {
                return NoContent(); // HTTP 204
            }
            else
            {
                return NotFound(); // HTTP 404 if game was not found
            }
        }
    }
}
