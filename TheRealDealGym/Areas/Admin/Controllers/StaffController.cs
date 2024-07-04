using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Trainer;
using TheRealDealGym.Infrastructure.Data.Models;
using static TheRealDealGym.Core.Constants.AdminConstants;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    public class StaffController : AdminBaseController
    {
        private readonly ITrainerService trainerService;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public StaffController(ITrainerService _trainerService, IUserService _userService, UserManager<ApplicationUser> _userManager)
        {
            trainerService = _trainerService;
            userService = _userService;
            userManager = _userManager;
        }

        /// <summary>
        /// This action gets all the trainers full names.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllTrainersQueryModel model)
        {
            var trainers = await trainerService.AllTrainersAsync(
                model.OrderBy,
                model.CurrentPage,
                model.TrainersPerPage);

            model.TotalTrainersCount = trainers.TrainersCount;
            model.Trainers = trainers.Trainers;

            return View(model);
        }

        /// <summary>
        /// This action displays the full information about the class upon pressing the "Details" button.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(Guid trainerId)
        {
            if (await trainerService.ExistsByTrainerIdAsync(trainerId) == false)
            {
                return BadRequest();
            }

            var model = await trainerService.GetTrainerDetailsAsync(trainerId);
            model.FullName = await userService.UserFullNameAsync(model.UserId);

            return View(model);
        }

        /// <summary>
        /// This action makes a Trainer admin.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> MakeAdmin(Guid trainerId)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await trainerService.ExistsByTrainerIdAsync(trainerId) == false)
            {
                return BadRequest();
            }

            var userId = await trainerService.GetUserIdByTrainerIdAsync(trainerId);

            var trainer = await userManager.FindByIdAsync(userId.ToString());

            if (await userManager.IsInRoleAsync(trainer, AdminRole))
            {
                return BadRequest();
            }

            await userManager.AddToRoleAsync(trainer, AdminRole);

            return RedirectToAction(nameof(Index), "Staff");
        } 
    }
}
