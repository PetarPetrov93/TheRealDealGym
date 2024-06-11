using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Dedicated to managing job openings, applications, and the application lifecycle.
    /// </summary>
    public class CareerController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
