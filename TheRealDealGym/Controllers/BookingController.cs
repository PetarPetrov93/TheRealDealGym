using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Responsible for managing the logged-in user bookings and is only visible for registered non-trainer users.
    /// </summary>
    public class BookingController : BaseController
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        /// <summary>
        /// This action displays all the bookings the logged-in user has made. Accesible through the "My Bookings" button.
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This action is responsible for booking for a specific class from the "Schedule" page.
        /// </summary>
        [HttpPost]
        public IActionResult Book()
        {
            //No view needed for this action.
            
            return RedirectToAction("Index", "Class");
        }

        /// <summary>
        /// This action is responsible for cancelling a booking for a specific class from the "Schedule" page or from the "My Bookings" page.
        /// </summary>
        [HttpPost]
        public IActionResult CancelBooking()
        {
            //No view needed for this action.
            return RedirectToAction("Index", "Class");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
    }
}
