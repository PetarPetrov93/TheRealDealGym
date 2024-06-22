using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheRealDealGym.Attributes;
using TheRealDealGym.Core.Contracts;
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
    }
}
