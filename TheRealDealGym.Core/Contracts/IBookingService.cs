using TheRealDealGym.Core.Models.Booking;

namespace TheRealDealGym.Core.Contracts
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingModel>> AllUserBookingsAsync(Guid userId);
        Task BookAsync(Guid classId, Guid userId);
        Task CancelBookingAsync(Guid bookingId);
    }
}
