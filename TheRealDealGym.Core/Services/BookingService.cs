using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Booking;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    /// <summary>
    /// The service responsible for operations with Booking entity.
    /// </summary>
    public class BookingService : IBookingService
    {
        private readonly IRepository repository;

        public BookingService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// This method returns all bookings made by the signed-in user.
        /// </summary>
        public async Task<IEnumerable<BookingModel>> AllUserBookingsAsync(Guid userId)
        {
            return await repository.AllReadOnly<Booking>()
                .Where(b => b.UserId == userId)
                .Include(b => b.Class)
                .Select(b => new BookingModel()
                {
                    Id = b.Id,
                    Class = b.Class.Title,
                    Date = b.Class.DateAndTime.ToString("dd/MM/yyyy"),
                    Time = b.Class.DateAndTime.ToString("HH:mm")
                })
                .ToListAsync();
        }

        /// <summary>
        /// This method implements the booking of a class.
        /// </summary>
        public async Task BookAsync(Guid classId, Guid userId)
        {
            var classToBook = await repository.GetByIdAsync<Class>(classId);

            if (classToBook != null)
            {
                var newBooking = new Booking()
                {
                    UserId = userId,
                    ClassId = classId,
                };

                await repository.AddAsync(newBooking);
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method implements the cancellation of a booked class.
        /// </summary>
        public async Task CancelBookingAsync(Guid bookingId)
        {
            var bookingToCancel = await repository.GetByIdAsync<Booking>(bookingId);

            if (bookingToCancel != null)
            {
                await repository.DeleteAsync<Booking>(bookingToCancel);
                await repository.SaveChangesAsync();
            }
        }
    }
}
