using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Responsible for managing the logged-in user bookings and is only visible for registered non-trainer users.
    /// </summary>
    public class BookingController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
