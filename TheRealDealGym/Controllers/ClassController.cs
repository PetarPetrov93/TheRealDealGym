using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheRealDealGym.Attributes;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Class;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Responisble for the page with the list of all classes.
    /// a registered non-trainer user can book class, view details and cancel class.
    /// a trainer can view all classes, add class, edit and remove his own classes.
    /// </summary>
    public class ClassController : BaseController
    {
        private readonly IClassService classService;
        private readonly ITrainerService trainerService;

        public ClassController(IClassService _classService, ITrainerService _trainerService)
        {
            classService = _classService;
            trainerService = _trainerService;
        }

        /// <summary>
        /// This action displays the list of all classes and implements a search and filter options.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllClassesQueryModel model)
        {
            var classes = await classService.AllAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.ClassesPerPage);

            model.TotalClassesCount = classes.TotalClassesCount;
            model.Classes = classes.Classes;
            model.Categories = await classService.AllSportNamesAsync();

            return View(model);
        }

        /// <summary>
        /// This action displays the full information about the class upon pressing the "Details" button.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(Guid classId)
        {
            if (await classService.ExistsAsync(classId) == false)
            {
                return BadRequest();
            }

            var model = await classService.ClassDetailsByIdAsync(classId);

            return View(model);
        }

        /// <summary>
        /// This method returns a form to fill in order to add a new class.
        /// </summary>
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Add()
        {
            var model = new ClassFormModel()
            {
                Rooms = await classService.AllRoomAsync(),
                Sports = await classService.AllSportAsync()
            };
            return View(model);
        }

        /// <summary>
        /// This method handles the input infromation from the form and creates a new class.
        /// </summary>
        [HttpPost]
        [MustBeTrainer]
        public async Task<IActionResult> Add(ClassFormModel model)
        {
            if (await classService.RoomExistsAsync(model.RoomId) == false)
            {
                ModelState.AddModelError(nameof(model.RoomId), "Room does not exist!");
            }

            if (await classService.SportExistsAsync(model.SportId) == false)
            {
                ModelState.AddModelError(nameof(model.SportId), "Sport does not exist!");
            }

            if (ModelState.IsValid == false)
            {
                model.Rooms = await classService.AllRoomAsync();
                model.Sports = await classService.AllSportAsync();

                return View(model);
            }

            Guid? trainerId = await trainerService.GetTrainerIdAsync(User.GetId());

            if (trainerId.HasValue == false)
            {
                return BadRequest();
            }

            try
            {
                Guid newClassId = await classService.CreateAsync(model, trainerId.Value);
                return RedirectToAction(nameof(Details), new { classId = newClassId });
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message); // THIS LINE SHOULD BE CHANGED WITH TempData["ErrorMessage"] = ex.Message; WHEN IMPLEMENT TOASTR
                model.Rooms = await classService.AllRoomAsync();
                model.Sports = await classService.AllSportAsync();
                return View(model);
            }
            
        }

        /// <summary>
        /// This method returns a form, pre-filled with the information of the class the trainer wants to edit.
        /// </summary>
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Edit(Guid classId)
        {
            if (await classService.ExistsAsync(classId) == false)
            {
                return BadRequest();
            }

            if (await classService.HasTrainerWithIdAsync(classId, User.GetId()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await classService.GetClassFormModelByIdAsync(classId);

            return View(model);
        }

        /// <summary>
        /// This method handles the editted information from the trainer and saves the changes.
        /// </summary>
        [HttpPost]
        [MustBeTrainer]
        public async Task<IActionResult> Edit(Guid classId, ClassFormModel model)
        {
            if (await classService.ExistsAsync(classId) == false)
            {
                return BadRequest();
            }

            if (await classService.HasTrainerWithIdAsync(classId, User.GetId()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await classService.RoomExistsAsync(model.RoomId) == false)
            {
                ModelState.AddModelError(nameof(model.RoomId), "Room does not exist!");
            }

            if (await classService.SportExistsAsync(model.SportId) == false)
            {
                ModelState.AddModelError(nameof(model.SportId), "Sport does not exist!");
            }

            if (ModelState.IsValid == false)
            {
                model.Rooms = await classService.AllRoomAsync();
                model.Sports = await classService.AllSportAsync();

                return View(model);
            }

            await classService.EditAsync(classId, model);

            return RedirectToAction(nameof(Details), new { classId });
        }

        /// <summary>
        /// This method gets the information about the class that has to be deleted.
        /// </summary>
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Delete(Guid classId)
        {
            if (await classService.ExistsAsync(classId) == false)
            {
                return BadRequest();
            }

            if (await classService.HasTrainerWithIdAsync(classId, User.GetId()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var classToDelete = await classService.ClassDetailsByIdAsync(classId);

            var model = new ClassDetailsModel()
            {
                Id = classToDelete.Id,
                Title = classToDelete.Title,
                Description = classToDelete.Description,
                Date = classToDelete.Date,
                Time = classToDelete.Time,
                Price = classToDelete.Price,
                Trainer = classToDelete.Trainer,
                Sport = classToDelete.Sport,
                Room = classToDelete.Room,
                AvaliableSpaces = classToDelete.AvaliableSpaces

            };

            return View(model);
        }

        /// <summary>
        /// This method deteles the given class.
        /// </summary>
        [HttpPost]
        [MustBeTrainer]
        public async Task<IActionResult> Delete(ClassDetailsModel model)
        {
            if (await classService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await classService.HasTrainerWithIdAsync(model.Id, User.GetId()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await classService.DeleteAsync(model.Id);

            return RedirectToAction("Index","Trainer");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
    }
}
