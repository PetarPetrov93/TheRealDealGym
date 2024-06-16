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
        public async Task<IActionResult> Index()
        {


            return View();
        }

        [AllowAnonymous]
        public IActionResult Info()
        {
            return View();
        }
    }
}
