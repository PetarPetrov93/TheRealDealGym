using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Class;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    /// <summary>
    /// The service responsible for operations with Class entity.
    /// </summary>
    public class ClassService : IClassService
    {
        private readonly IRepository repository;

        public ClassService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// This method filters the schedule by keyword or by selected option from the dropdown menu.
        /// </summary>
        public async Task<ClassQueryModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            ClassSorting sorting = ClassSorting.DateAscending,
            int currentPage = 1,
            int classesPerPage = 1)
        {
            var classesToShow = repository.AllReadOnly<Class>();

            if (category != null)
            {
                classesToShow = classesToShow
                    .Where(c => c.Sport.Category == category);
            }

            if (searchTerm != null)
            {
                string normalizesSearchTerm = searchTerm.ToLower();
                classesToShow = classesToShow
                    .Where(c => (c.Title.ToLower().Contains(normalizesSearchTerm)) ||
                                 c.Sport.Category.Contains(normalizesSearchTerm) ||
                                 c.Trainer.User.FirstName.Contains(normalizesSearchTerm) ||
                                 c.Trainer.User.LastName.Contains(normalizesSearchTerm));
            }

            classesToShow = sorting switch
            {
                ClassSorting.DateAscending => classesToShow.OrderBy(c => c.DateAndTime.Date),
                ClassSorting.DateDescending => classesToShow.OrderByDescending(c => c.DateAndTime.Date),
                ClassSorting.TimeAscending => classesToShow.OrderBy(c => c.DateAndTime.TimeOfDay),
                ClassSorting.TimeDescending => classesToShow.OrderByDescending(c => c.DateAndTime.TimeOfDay),
                _ => classesToShow.OrderBy(c => c.DateAndTime)
            };

            var classes = await classesToShow
                .Skip((currentPage - 1) * classesPerPage)
                .Take(classesPerPage)
                .Select(c => new ClassScheduleModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Date = c.DateAndTime.ToString("dd/MM/yyyy"),
                    Time = c.DateAndTime.ToString("HH:mm"),
                    Trainer = $"{c.Trainer.User.FirstName} {c.Trainer.User.LastName}",
                    Price = c.Price
                })
                .ToListAsync();

            int totalClasses = await classesToShow.CountAsync();

            return new ClassQueryModel()
            {
                Classes = classes,
                TotalClassesCount = totalClasses,
            };
        }

        /// <summary>
        /// This method gets all the classes which are currently created.
        /// </summary>
        public async Task<IEnumerable<ClassScheduleModel>> AllClassesAsync()
        {
            return await repository.AllReadOnly<Class>()
                .Include(c => c.Trainer)
                .Include(c => c.Sport)
                .Include(c => c.Room)
                .Select(c => new ClassScheduleModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Time = c.DateAndTime.ToString("dd/MM/yyyy"),
                    Price = c.Price,
                    Trainer = $"{c.Trainer.User.FirstName} {c.Trainer.User.LastName}"
                })
                .ToListAsync();
        }

        /// <summary>
        /// This method gets all sport categories.
        /// </summary>
        public async Task<IEnumerable<string>> AllSportCategoriesAsync()
        {
            return await repository.AllReadOnly<Sport>()
                .Select(s => s.Category)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// This method returns the full details of a specific class when "Details" button is pressed.
        /// </summary>
        public async Task<ClassDetailsModel> ClassDetailsAsync(Guid classId)
        {
            var classEntity = await repository.GetByIdAsync<Class>(classId);
            var classDetailsModel = new ClassDetailsModel()
            {
                Id = classEntity!.Id,
                Title = classEntity.Title,
                Description = classEntity.Description,
                Time = classEntity.DateAndTime.ToString("dd/MM/yyyy"),
                Price = classEntity.Price,
                Trainer = $"{classEntity.Trainer.User.FirstName} {classEntity.Trainer.User.LastName}",
                Sport = classEntity.Sport.Title,
                Room = classEntity.Room.Name,
                AvaliableSpaces = classEntity.Room.Capacity - BookingsForCurrentClass(classEntity.Id)
            };
            return classDetailsModel;
        }

        /// <summary>
        /// This private method gets the count of all bookings made for a given class so far.
        /// </summary>
        private int BookingsForCurrentClass(Guid classId)
        {
            return repository.AllReadOnly<Booking>()
                .Where(b => b.ClassId == classId)
                .Count();
        }
    }
}
