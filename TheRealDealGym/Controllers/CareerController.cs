using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Dedicated to managing job openings, applications, and the application lifecycle.
    /// </summary>
    public class CareerController : BaseController
    {
        [AllowAnonymous] //Subject to change depending on whether a non-registered user should be able to apply or not.
        public IActionResult Index()
        {
            return View();
        }
    }
}
