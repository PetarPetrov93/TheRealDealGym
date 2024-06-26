using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Trainer;

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
    }
}
