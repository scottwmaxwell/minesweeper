using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    public class LoginController : Controller
    {
        SecurityService securityService = new SecurityService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            if (securityService.IsValid(user))
            {
                user = securityService.GetUser(user.UserName);
                return RedirectToAction("Index", "Gameboard");
            }
            else
            {
                return View("LoginFailure", user);
            }
        }
    }
}
