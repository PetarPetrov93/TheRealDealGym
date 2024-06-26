using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheRealDealGym.Attributes;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Job;
using TheRealDealGym.Infrastructure.Data.Models;
using static TheRealDealGym.Core.Constants.MessageConstants;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Dedicated to managing job openings, applications, and the application lifecycle.
    /// </summary>
    public class CareerController : BaseController
    {
        private readonly IJobService jobService;
        private readonly UserManager<ApplicationUser> userManager;

        public CareerController(IJobService _jobService, UserManager<ApplicationUser> _userManager)
        {
            jobService = _jobService;
            userManager = _userManager;
        }


        /// <summary>
        /// This action gets all job adverts basic information.
        /// </summary>
        [HttpGet]
        [IsNotATrainer]
        public async Task<IActionResult> Index()
        {
            var model = await jobService.AllActiveJobAdvertsForUsersAsync(User.GetId());

            return View(model);
        }

        /// <summary>
        /// This action displays the full information about the job advert upon pressing the "Details" button.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(Guid jobAdvertId)
        {
            if (await jobService.JobAdvertExistsByIdAsync(jobAdvertId) == false)
            {
                return BadRequest();
            }

            var model = await jobService.GetJobAdvertByIdAsync(jobAdvertId);

            return View(model);
        }

        /// <summary>
        /// This method opens the form for applying for a job.
        /// </summary>
        [HttpGet]
        [IsNotATrainer]
        public async Task<IActionResult> Apply(Guid jobAdvertId)
        {
            var jobAdvert = await jobService.GetJobAdvertByIdAsync(jobAdvertId);
            if (jobAdvert == null)
            {
                return NotFound();
            }

            var user = await userManager.GetUserAsync(User);
            var applications = user.AppliedJobs;

            if (applications.Any(a => a.JobAdvertId == jobAdvertId))
            {
                return BadRequest();
            }

            return View();
        }

        /// <summary>
        /// This method creates the new Application for the signed-in user.
        /// </summary>
        [HttpPost]
        [IsNotATrainer]
        public async Task<IActionResult> Apply(Guid jobAdvertId, ApplicationFormModel model)
        {
            var user = await userManager.GetUserAsync(User);
            var applications = user.AppliedJobs;

            if (applications.Any(a => a.JobAdvertId == jobAdvertId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await jobService.CreateJobApplicationAsync(jobAdvertId, User.GetId(), model);

            TempData[MessageSuccess] = "You have successfully applied for this role!";
            return RedirectToAction(nameof(Index), "Career");
        }

    }
}
