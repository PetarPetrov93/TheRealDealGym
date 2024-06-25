using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheRealDealGym.Attributes;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Room;
using TheRealDealGym.Core.Models.Trainer;
using TheRealDealGym.Core.Services;
using static TheRealDealGym.Core.Constants.AdminConstants;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Controller for trainers.
    /// Accesible through "My Profile" button.
    /// </summary>
    public class TrainerController : BaseController
    {
        private readonly ITrainerService trainerService;
        private readonly IUserService userService;

        public TrainerController(ITrainerService _trainerService, IUserService _userService)
        {
            trainerService = _trainerService;
            userService = _userService;

        }

        /// <summary>
        /// This action gets all the classes which the logged-in trainer has created.
        /// </summary>
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Index()
        {
            var userId = User.GetId();

            IEnumerable<TrainerClassModel> model;

            if (await trainerService.ExistsByUserIdAsync(userId))
            {
                var trainerId = await trainerService.GetTrainerIdAsync(userId);

                model = await trainerService.AllTrainerClassesAsync(trainerId);

                return View(model);
            }

            return Unauthorized();
        }

        /// <summary>
        /// This method returns a form, pre-filled with the information about the trainer.
        /// </summary>
        [HttpGet]
        [MustBeTrainer]
        public async Task<IActionResult> Edit(Guid trainerId)
        {
            if (await trainerService.ExistsByTrainerIdAsync(trainerId) == false)
            {
                return BadRequest();
            }

            var model = await trainerService.GetTrainerDetailsAsync(trainerId);

            return View(model);
        }

        /// <summary>
        /// This method handles the editted information for the trainer and saves the changes.
        /// </summary>
        [HttpPost]
        [MustBeTrainer]
        public async Task<IActionResult> Edit(Guid trainerId, TrainerDetailsModel model)
        {
            if (await trainerService.ExistsByTrainerIdAsync(trainerId) == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {

                return View(model);
            }

            await trainerService.EditAsync(trainerId, model);

            return RedirectToAction(nameof(Index), "Trainer");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
    }
}
