using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    public class RegisterController : Controller
    {
        SecurityService securityService = new SecurityService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterUser(UserModel user)
        {
            ViewBag.message = securityService.Save(user) ? "Successfully registered account for " + user.FirstName + " " + user.LastName : "Failed to register account";
            
            return View("RegisterSuccess");
        }
    }
}
