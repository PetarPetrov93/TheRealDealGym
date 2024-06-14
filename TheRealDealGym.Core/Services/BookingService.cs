using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Booking;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace TheRealDealGym.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository repository;

        public BookingService(IRepository _repository)
        {
            repository = _repository;
        }

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

    }
}
