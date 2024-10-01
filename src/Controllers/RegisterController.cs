using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using Minesweeper.Utility;

namespace Minesweeper.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SecurityService _securityService;
        private readonly Ilogger logger;

        public RegisterController(SecurityService securityService, Ilogger logger)
        {
            _securityService = securityService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.Info("Loading the Register Index page.");
            return View();
        }

        public IActionResult RegisterUser(UserModel user)
        {
            logger.Info("Processing user registration for: " + user.ToString());
            ViewBag.message = _securityService.Save(user) ? "Successfully registered account for " + user.FirstName + " " + user.LastName : "Failed to register account";
            
            return View("RegisterSuccess");
        }
    }
}
