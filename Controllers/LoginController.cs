using Microsoft.AspNetCore.Mvc;

namespace Minesweeper.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
