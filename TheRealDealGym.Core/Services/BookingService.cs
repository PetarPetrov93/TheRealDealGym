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
            await ExpireClasses(userId);
            return await repository.AllReadOnly<Booking>()
                .Where(b => b.UserId == userId)
                .Include(b => b.Class)
                .Select(b => new BookingModel()
                {
                    Id = b.Id,
                    Class = b.Class.Title,
                    Date = b.Class.DateAndTime.ToString("dd/MM/yyyy"),
                    Time = b.Class.DateAndTime.ToString("HH:mm"),
                    ClassId = b.ClassId
                })
                .ToListAsync();
        }

        /// <summary>
        /// This method implements the booking of a class.
        /// </summary>
        public async Task BookAsync(Guid classId, Guid userId)
        {
            var classToBook = await repository.GetByIdAsync<Class>(classId);

            if (classToBook != null && await HasUserBookedForThisClass(userId, classId) == false)
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
            if (await ExistsByIdAsync(bookingId))
            {
                await repository.DeleteAsync<Booking>(bookingId);
                await repository.SaveChangesAsync();
            }
            
        }

        /// <summary>
        /// This method checks if a booking exists by Id.
        /// </summary>
        public async Task<bool> ExistsByIdAsync(Guid bookingId)
        {
            return await repository.AllReadOnly<Booking>()
                .AnyAsync(b => b.Id == bookingId);
        }

        public async Task<Guid> GetBookingIdAsync(Guid userId, Guid classId)
        {
            return await repository.AllReadOnly<Booking>()
                .Where(b => b.UserId == userId && b.ClassId == classId)
                .Select(b => b.Id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// This method checks if a user has already booked for the class he is currently trying to book.
        /// </summary>
        public async Task<bool> HasUserBookedForThisClass(Guid userId, Guid classId)
        {
            var existingBooking = await repository.AllReadOnly<Booking>()
                .Where(b => b.UserId == userId && b.ClassId == classId)
                .FirstOrDefaultAsync();

            return existingBooking != null;
        }

        /// <summary>
        /// This method expires classes which due date and time has passed.
        /// </summary>
        private async Task ExpireClasses(Guid userId)
        {
            var allClasses = await repository.AllReadOnly<Class>()
                .ToListAsync();
            allClasses = allClasses
                .Where(c => c.DateAndTime < DateTimeOffset.Now).ToList();

            foreach (var currClass in allClasses)
            {
                await repository.DeleteAsync<Class>(currClass.Id);
                await repository.SaveChangesAsync();
            }
        }
    }
}
