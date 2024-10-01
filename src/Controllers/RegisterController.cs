using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using Minesweeper.Utility;

namespace Minesweeper.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SecurityService _securityService;

        public RegisterController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        public IActionResult Index()
        {
            MyLogger.GetInstance().Info("Loading the Register Index page.");
            return View();
        }

        public IActionResult RegisterUser(UserModel user)
        {
            MyLogger.GetInstance().Info("Processing user registration for: " + user.ToString());
            ViewBag.message = _securityService.Save(user) ? "Successfully registered account for " + user.FirstName + " " + user.LastName : "Failed to register account";
            
            return View("RegisterSuccess");
        }
    }
}
