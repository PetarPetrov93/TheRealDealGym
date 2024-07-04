using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheRealDealGym.Core.Models.Home;
using TheRealDealGym.Models;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// The controller for the homepage and the about pages of the app.
    /// </summary>
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var imageList = new List<string>() { "Gym.jpeg", "Yoga.jpeg", "Grappling.jpeg", "Boxing.jpeg", "Swimming pool.jpeg" };
            var model = new HomeViewModel { Images = imageList };
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
            if (statusCode == 404)
            {
                return View("Error404");
            }
            if (statusCode == 500)
            {
                return View("Error500");
            }

            return View();
        }
    }
}
