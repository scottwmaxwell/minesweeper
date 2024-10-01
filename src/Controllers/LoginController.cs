using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using Minesweeper.Utility;
using NLog;

namespace Minesweeper.Controllers
{
    public class LoginController : Controller
    {
        private readonly SecurityService _securityService;
        private readonly Ilogger logger;

        public LoginController(SecurityService securityService, Ilogger logger)
        {
            _securityService = securityService;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.Info("Loading the Login Index page.");
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            logger.Info("Processing login.");
            if (_securityService.IsValid(user))
            {
                logger.Info("Login Successful.");
                user = _securityService.GetUser(user.UserName);
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetString("id", user.Id.ToString());
                return RedirectToAction("Index", "Gameboard");
            }
            else
            {
                logger.Info("Login Failed.");
                HttpContext.Session.Remove("username");
                HttpContext.Session.Remove("id");
                return View("LoginFailure", user);
            }
        }
    }
}
