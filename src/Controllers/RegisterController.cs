using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;

namespace Minesweeper.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterUser(UserModel user)
        {
            SecurityDAO securityDAO = new SecurityDAO();
            ViewBag.message = securityDAO.RegisterUser(user) ? "Successfully registered account for " + user.firstName + " " + user.lastName : "Failed to register account";
            return View();
        }
    }
}
