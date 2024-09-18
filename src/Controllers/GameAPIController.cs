using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GameAPIController : ControllerBase
    {
        [HttpPost("saveGame")]
        public ActionResult SaveGame(SavedGame game)
        {
            // TODO: Get User Session and Use it to get User ID

            // TODO: Save game to Database

            throw new NotImplementedException();
        }

        [HttpGet("showSavedGames/{gameId}")]
        public ActionResult ShowSavedGames(string gameId)
        {
            if (gameId != null)
            {
                // TODO: Return the single game
            }
            else
            {
                // TODO: Return all games available for the user Id
            }


            throw new NotImplementedException();
        }

        [HttpDelete("deleteOneGame/{gameId}")]
        public ActionResult DeleteOneGame(string gameId) 
        {    
            // TODO: Delete Game from database based on gameId

            throw new NotImplementedException(); 
        }
    }
}
