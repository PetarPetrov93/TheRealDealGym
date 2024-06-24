using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Job;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    /// <summary>
    /// Responisble for the page with the list of all jobs.
    /// only an admin can add and remove job adverts.
    /// </summary>
    public class JobAdvertController : AdminBaseController
    {
        private readonly IJobService jobService;

        public JobAdvertController(IJobService _jobService)
        {
            jobService = _jobService;
        }

        /// <summary>
        /// This action gets all job adverts basic information.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await jobService.AllJobsAsync(User.GetId());

            return View(model);
        }

        /// <summary>
        /// This method returns a form to fill in order to add a new sport.
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// This method handles the input infromation from the form and creates a new sport.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(JobAdvertModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            Guid newJobAdvert = await jobService.CreateAsync(model);
            return RedirectToAction(nameof(Index), "JobAdvert");
        }

        /// <summary>
        /// This method returns a form, pre-filled with the information of the sport the admin wants to edit.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid jobAdvertId)
        {
            if (await jobService.ExistsByIdAsync(jobAdvertId) == false)
            {
                return BadRequest();
            }

            var model = await jobService.GetByIdAsync(jobAdvertId);

            return View(model);
        }

        /// <summary>
        /// This method handles the editted information from the admin and saves the changes.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(Guid jobAdvertId, JobAdvertModel model)
        {
            if (await jobService.ExistsByIdAsync(jobAdvertId) == false)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {

                return View(model);
            }

            await jobService.EditAsync(jobAdvertId, model);

            return RedirectToAction(nameof(Details), new { jobAdvertId });
        }

        /// <summary>
        /// This method activates the given sport.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Activate(Guid jobAdvertId)
        {
            if (await jobService.ExistsByIdAsync(jobAdvertId) == false)
            {
                return BadRequest();
            }

            await jobService.ActivateAsync(jobAdvertId);

            return RedirectToAction(nameof(Index), "JobAdvert");
        }

        /// <summary>
        /// This method deactivates the given sport.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Deactivate(Guid jobAdvertId)
        {
            if (await jobService.ExistsByIdAsync(jobAdvertId) == false)
            {
                return BadRequest();
            }

            await jobService.DeactivateAsync(jobAdvertId);

            return RedirectToAction(nameof(Index), "JobAdvert");
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
    }
}
