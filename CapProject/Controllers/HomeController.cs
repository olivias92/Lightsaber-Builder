using System.Diagnostics;
using CapProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapProject.Controllers
{
    public class HomeController : Controller {
        // Logger, doesn't do much but won't hurt to keep
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        } 


        // Methods for all simple pages and to redirect to the starts
        // of New Build and My Builds
        public IActionResult Index() {
            return View();
        } // End method

        public IActionResult NewBuild() {
            return View(); 
        } // End method

        public IActionResult MyBuilds() {
            return View();
        } // End method

        public IActionResult Help() {
            return View();
        } // End method

        public IActionResult About() {
            return View();
        } // End method


        // VS recommended for an error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    } // End class
} // End namespace
