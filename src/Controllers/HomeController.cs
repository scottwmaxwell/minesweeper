using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Utility;
using NLog;
using System.Diagnostics;

namespace Minesweeper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MyLogger.GetInstance().Info("Loading Home page.");
            return View();
        }

        public IActionResult Privacy()
        {
            MyLogger.GetInstance().Info("Loading Privacy page.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            MyLogger.GetInstance().Info("There was an error.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
