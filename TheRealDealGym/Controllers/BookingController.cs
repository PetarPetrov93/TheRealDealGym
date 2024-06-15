using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Responsible for managing the logged-in user bookings and is only visible for registered non-trainer users.
    /// </summary>
    public class BookingController : BaseController
    {
        /// <summary>
        /// This action displays all the bookings the logged-in user has made. Accesible through the "My Bookings" button.
        /// </summary>
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This action is responsible for booking for a specific class from the "Schedule" page.
        /// </summary>
        [AllowAnonymous]
        public IActionResult Book()
        {
            //No view needed for this action.
            return RedirectToAction("Index", "Class");
        }

        /// <summary>
        /// This action is responsible for cancelling a booking for a specific class from the "Schedule" page.
        /// </summary>
        [AllowAnonymous]
        public IActionResult CancelBooking()
        {
            //No view needed for this action.
            return RedirectToAction("Index", "Class");
        }

        [AllowAnonymous]
        public IActionResult Info()
        {
            return View();
        }
    }
}
