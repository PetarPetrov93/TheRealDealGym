using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Services;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    public class StaffController : AdminBaseController
    {
        private readonly ITrainerService trainerService;
        private readonly IUserService userService;

        public StaffController(ITrainerService _trainerService, IUserService _userService)
        {
            trainerService = _trainerService;
            userService = _userService;

        }

        /// <summary>
        /// This action gets all the trainers full names.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await trainerService.AllTrainersAsync();
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
    }
}
