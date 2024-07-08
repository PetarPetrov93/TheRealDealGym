using Microsoft.EntityFrameworkCore;
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
            string? sportTitle = null,
            string? searchTerm = null,
            ClassSorting sorting = ClassSorting.DateAscending,
            int currentPage = 1,
            int classesPerPage = 6)
        {
            await ExpireClasses();
            var classesToShow = repository.AllReadOnly<Class>();

            if (sportTitle != null)
            {
                classesToShow = classesToShow
                    .Where(c => c.Sport.Title == sportTitle);
            }

            if (searchTerm != null)
            {
                string normalizesSearchTerm = searchTerm.ToLower();
                classesToShow = classesToShow
                    .Where(c => (c.Title.ToLower().Contains(normalizesSearchTerm)) ||
                                 c.Sport.Title.Contains(normalizesSearchTerm) ||
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
        /// This method gets all room names.
        /// </summary>
        public async Task<IEnumerable<RoomCategoryModel>> AllRoomAsync()
        {
            return await repository.AllReadOnly<Room>()
                .Select(r => new RoomCategoryModel()
                {
                    Id = r.Id,
                    Name = r.Type
                })
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// This method gets all sport categories.
        /// </summary>
        public async Task<IEnumerable<SportCategoryModel>> AllSportAsync()
        {
            return await repository.AllReadOnly<Sport>()
                .Select(s => new SportCategoryModel()
                {
                    Id = s.Id,
                    Name = s.Title
                })
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// This method gets the names of all the sports.
        /// </summary>
        public async Task<IEnumerable<string>> AllSportNamesAsync()
        {
            return await repository.AllReadOnly<Sport>()
                .Select(s => s.Title)
                .Distinct()
                .ToListAsync();
        }


        /// <summary>
        /// This method fetches the full details of a class with a given Id when the "Detaild" button is pressed.
        /// </summary>
        public async Task<ClassDetailsModel> ClassDetailsByIdAsync(Guid classId)
        {
            return await repository.AllReadOnly<Class>()
                .Where(c => c.Id == classId)
                .Select(c => new ClassDetailsModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Date = c.DateAndTime.ToString("dd/MM/yyyy"),
                    Time = c.DateAndTime.ToString("HH:mm"),
                    Price = c.Price,
                    Trainer = $"{c.Trainer.User.FirstName} {c.Trainer.User.LastName}",
                    Sport = c.Sport.Title,
                    Room = c.Room.Type,
                    AvaliableSpaces = c.Room.Capacity - BookingsForCurrentClass(classId)
                })
                .FirstAsync();
        }

        /// <summary>
        /// This method creates a new class.
        /// It also checks if the room is available at this time slot and checks for potential overlapping with other classes.
        /// </summary>
        public async Task<Guid> CreateAsync(ClassFormModel model, Guid trainerId)
        {
            Class classToCreate = new Class()
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                SportId = model.SportId,
                RoomId = model.RoomId,
                DateAndTime = DateTime.Parse($"{model.Date} {model.Time}"),
                TrainerId = trainerId
            };

            var newClassDateTime = classToCreate.DateAndTime;

            var overlappingClasses = await repository.AllReadOnly<Class>()
                .Where(c => c.RoomId == model.RoomId &&
                    (
                     (c.DateAndTime < newClassDateTime && c.DateAndTime.AddMinutes(60) > newClassDateTime) ||
                     (c.DateAndTime >= newClassDateTime && c.DateAndTime < newClassDateTime.AddMinutes(60))
                    )
                )
                .ToListAsync();

            if (overlappingClasses.Any())
            {
                throw new Exception("Selected room is not available for the chosen time slot.");
            }

            if (newClassDateTime <= DateTimeOffset.Now)
            {
                throw new Exception("Please set a valid date and time for this class.");
            }

            await repository.AddAsync(classToCreate);
            await repository.SaveChangesAsync();

            return classToCreate.Id;
        }

        /// <summary>
        /// This method performs a soft delete on a given class by setting the IsDeleted property to "true".
        /// </summary>
        public async Task DeleteAsync(Guid classId)
        {
            await repository.DeleteAsync<Class>(classId);
            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// This method edits a selected by the trainer class.
        /// </summary>
        public async Task EditAsync(Guid classId, ClassFormModel model)
        {
            var classToEdit = await repository.GetByIdAsync<Class>(classId);

            if (classToEdit != null)
            {
                classToEdit.Title = model.Title;
                classToEdit.Description = model.Description;
                classToEdit.Price = model.Price;
                classToEdit.SportId = model.SportId;
                classToEdit.RoomId = model.RoomId;
                classToEdit.DateAndTime = DateTime.Parse($"{model.Date} {model.Time}");

                var newClassDateTime = classToEdit.DateAndTime;

                var overlappingClasses = await repository.AllReadOnly<Class>()
                    .Where(c => c.RoomId == model.RoomId &&
                           c.Id != classId &&
                        (
                         (c.DateAndTime < newClassDateTime && c.DateAndTime.AddMinutes(60) > newClassDateTime) ||
                         (c.DateAndTime >= newClassDateTime && c.DateAndTime < newClassDateTime.AddMinutes(60))
                        )
                    )
                    .ToListAsync();

                var isClassBooked = await repository.AllReadOnly<Booking>()
                    .AnyAsync(b => b.ClassId == classId);

                if (isClassBooked)
                {
                    throw new Exception("You cannot edit this class because users have already booked for it!");
                }
                if (overlappingClasses.Any())
                {
                    throw new Exception("Selected room is not available for the chosen time slot.");
                }

                if (newClassDateTime <= DateTimeOffset.Now)
                {
                    throw new Exception("Please set a valid date and time for this class.");
                }

                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method checks if a class with a given Id exists.
        /// </summary>
        public async Task<bool> ExistsAsync(Guid classId)
        {
            return await repository.AllReadOnly<Class>()
                 .AnyAsync(c => c.Id == classId);
        }

        /// <summary>
        /// This method maps a class entity to ClassFormModel by Id.
        /// </summary>
        public async Task<ClassFormModel?> GetClassFormModelByIdAsync(Guid classId)
        {
            var classToMap = await repository.AllReadOnly<Class>()
                .Where(c => c.Id == classId)
                .Select(c => new ClassFormModel()
                {
                    Title = c.Title,
                    Description = c.Description,
                    Price = c.Price,
                    SportId = c.SportId,
                    RoomId = c.RoomId,
                    Date = c.DateAndTime.ToString("dd/MM/yyyy"),
                    Time = c.DateAndTime.ToString("HH:mm")
                })
                .FirstOrDefaultAsync();

            if (classToMap != null)
            {
                classToMap.Sports = await AllSportAsync();
                classToMap.Rooms = await AllRoomAsync();
            }

            return classToMap;
        }

        /// <summary>
        /// This method checks the Trainer of the current class.
        /// </summary>
        public async Task<bool> HasTrainerWithIdAsync(Guid classId, Guid userId)
        {
            return await repository.AllReadOnly<Class>()
                .AnyAsync(c => c.Id == classId && c.Trainer.UserId == userId);
        }

        /// <summary>
        /// This method checks if the given room exists.
        /// </summary>
        public Task<bool> RoomExistsAsync(Guid roomId)
        {
            return repository.AllReadOnly<Room>()
                .AnyAsync(r => r.Id == roomId);
        }

        /// <summary>
        /// This method checks if the given sport exists.
        /// </summary>
        public Task<bool> SportExistsAsync(Guid sportId)
        {
            return repository.AllReadOnly<Sport>()
                .AnyAsync(s => s.Id == sportId);
        }

        /// <summary>
        /// This method checks if there are available spaces to book for a given class.
        /// </summary>
        public async Task<bool> HasAvailableSpacesAsync(Guid classId)
        {
            var currClass = await repository.AllReadOnly<Class>()
                .Where(c => c.Id == classId)
                .Include(c => c.Room)
                .FirstAsync();

            if (currClass!.Room.Capacity - BookingsForCurrentClass(classId) == 0)
            {
                return false;
            }
            return true;
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

        /// <summary>
        /// This method expires classes which due date and time has passed.
        /// </summary>
        private async Task ExpireClasses()
        {
            var allClasses = await repository.AllReadOnly<Class>().ToListAsync();
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
