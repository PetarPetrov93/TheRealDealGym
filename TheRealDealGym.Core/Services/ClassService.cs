using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Class;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    public class ClassService : IClassService
    {
        private readonly IRepository repository;

        public ClassService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<ClassModel>> AllUserBookingsAsync()
        {
            return await repository.AllReadOnly<Class>()
                .Include(c => c.Trainer)
                .Include(c => c.Sport)
                .Include(c => c.Room)
                .Select(c => new ClassModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Time = c.DateAndTime.ToString("dd/MM/yyyy"),
                    Price = c.Price,
                    Trainer = $"{c.Trainer.User.FirstName} {c.Trainer.User.LastName}",
                    Sport = c.Sport.Title,
                    Room = c.Room.Name,
                    AvaliableSpaces = c.Room.Capacity - BookingsForCurrentClass(c.Id)
                })
                .ToListAsync();
        }

        private int BookingsForCurrentClass(Guid classId)
        {
            return repository.AllReadOnly<Booking>()
                .Where(b => b.ClassId == classId)
                .Count();
        }
    }
}
