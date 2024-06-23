using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Dedicated to managing job openings, applications, and the application lifecycle.
    /// </summary>
    public class CareerController : BaseController
    {
        private readonly IJobService jobService;

        public CareerController(IJobService _jobService)
        {
            jobService = _jobService;
        }


        /// <summary>
        /// This action gets all job adverts basic information.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await jobService.AllJobsAsync();

            return View(model);
        }

        /// <summary>
        /// This action displays the full information about the job advert upon pressing the "Details" button.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(Guid jobAdvertId)
        {
            if (await jobService.ExistsByIdAsync(jobAdvertId) == false)
            {
                return BadRequest();
            }

            var model = await jobService.GetByIdAsync(jobAdvertId);

            return View(model);
        }

        [AllowAnonymous] //Subject to change depending on whether a non-registered user should be able to apply or not.
        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
    }
}
