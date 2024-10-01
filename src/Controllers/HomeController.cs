using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using Minesweeper.Utility;
using NLog;
using System.Diagnostics;

namespace Minesweeper.Controllers
{
    public class HomeController : Controller
    {
        private readonly Ilogger logger;

        // Initialize service when gameboard is created
        public HomeController(Ilogger logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.Info("Loading Home page.");
            return View();
        }

        public IActionResult Privacy()
        {
            logger.Info("Loading Privacy page.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            logger.Info("There was an error.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
