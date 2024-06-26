using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheRealDealGym.Attributes;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Booking;
using static TheRealDealGym.Core.Constants.MessageConstants;

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
        [IsNotATrainer]
        public async Task<IActionResult> Index()
        {
            IEnumerable<BookingModel> model;

            model = await bookingService.AllUserBookingsAsync(User.GetId());

            return View(model);
        }

        /// <summary>
        /// This action is responsible for booking for a specific class from the "Schedule" page.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Book(Guid classId)
        {
            Guid userId = User.GetId();

            if (await bookingService.HasUserBookedForThisClass(userId, classId))
            {
                return BadRequest();
            }

            await bookingService.BookAsync(classId, userId);

            TempData[MessageSuccess] = "You have successfully signed up for this activity!";
            return RedirectToAction("Index", "Class");
        }

        /// <summary>
        /// This action is responsible for cancelling a booking for a specific class from the "Schedule" page or from the "My Bookings" page.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CancelBooking(Guid bookingId)
        {
            try
            {
                await bookingService.CancelBookingAsync(bookingId);
                TempData[MessageError] = "You have successfully cacnelled your booking for this activity!";
                return RedirectToAction("Index", "Class");
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
