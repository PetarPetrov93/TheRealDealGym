﻿using TheRealDealGym.Core.Models.Booking;

namespace TheRealDealGym.Core.Contracts
{
    public interface IBookingService
    {
        Task<bool> ExistsByIdAsync(Guid bookingId);
        Task<IEnumerable<BookingModel>> AllUserBookingsAsync(Guid userId);
        Task BookAsync(Guid classId, Guid userId);
        Task CancelBookingAsync(Guid bookingId);
        Task<bool> HasUserBookedForThisClass(Guid userId, Guid classId);
        Task<Guid> GetBookingIdAsync(Guid userId, Guid classId);
    }
}
