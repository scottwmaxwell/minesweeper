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

        public LoginController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        public IActionResult Index()
        {
            MyLogger.GetInstance().Info("Loading the Login Index page.");
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            MyLogger.GetInstance().Info("Processing login.");
            if (_securityService.IsValid(user))
            {
                MyLogger.GetInstance().Info("Login Successful.");
                user = _securityService.GetUser(user.UserName);
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetString("id", user.Id.ToString());
                return RedirectToAction("Index", "Gameboard");
            }
            else
            {
                MyLogger.GetInstance().Info("Login Failed.");
                HttpContext.Session.Remove("username");
                HttpContext.Session.Remove("id");
                return View("LoginFailure", user);
            }
        }
    }
}
