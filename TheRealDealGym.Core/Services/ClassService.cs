﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
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
            int classesPerPage = 3)
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
        /// This method gets all room names.
        /// </summary>
        public async Task<IEnumerable<string>> AllRoomNamesAsync()
        {
            return await repository.AllReadOnly<Room>()
                .Select(r => r.Name)
                .Distinct()
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
                    Room = c.Room.Name,
                    AvaliableSpaces = c.Room.Capacity - BookingsForCurrentClass(classId)
                })
                .FirstAsync();
        }

        /// <summary>
        /// This method edits a selected by the trainer class.
        /// </summary>
        public async Task Edit(Guid classId, ClassFormModel model)
        {
            var classToEdit = await repository.GetByIdAsync<Class>(classId);

            if (classToEdit != null)
            {
                classToEdit.Title = model.Title;
                classToEdit.Description = model.Description;
                classToEdit.Price = model.Price;
                classToEdit.SportId = model.SportId;
                classToEdit.RoomId = model.RoomId;
                classToEdit.DateAndTime = DateTime.Parse($"{model.Date} {model.Time}", CultureInfo.InvariantCulture);

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
                classToMap.Sports = await AllSportCategoriesAsync();
                classToMap.Rooms = await AllRoomNamesAsync();
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

        public Task<bool> RoomExistsAsync(Guid roomId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method checks if the given category exists by name.
        /// </summary>
        public Task<bool> SportCategoryExistsAsync(Guid categoryId)
        {
            throw new NotImplementedException();
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
