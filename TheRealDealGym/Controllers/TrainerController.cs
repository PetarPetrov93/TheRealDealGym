using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Controller for trainers.
    /// Accesible through "My Profile" button.
    /// </summary>
    public class TrainerController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {


            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
    }
}
