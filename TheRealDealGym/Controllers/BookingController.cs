﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public async Task<IActionResult> Book(Guid classId)
        {
            //No view needed for this action.

            Guid userId = User.GetId();
            if (await bookingService.HasUserBookedForThisClass(userId, classId))
            {
                return BadRequest();
            }

            await bookingService.BookAsync(classId, userId);
            return RedirectToAction("Index", "Class");
        }

        /// <summary>
        /// This action is responsible for cancelling a booking for a specific class from the "Schedule" page or from the "My Bookings" page.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CancelBooking(Guid bookingId)
        {
            //No view needed for this action.

            try
            {
                await bookingService.CancelBookingAsync(bookingId);
                return RedirectToAction("Index", "Class");
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
    }
}
