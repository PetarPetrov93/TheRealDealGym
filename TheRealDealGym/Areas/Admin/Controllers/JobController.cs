using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Services;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    /// <summary>
    /// Responisble for the page with the list of all jobs.
    /// only an admin can add and remove job adverts.
    /// </summary>
    public class JobController : AdminBaseController
    {
        private readonly IJobService jobService;

        public JobController(IJobService _jobService)
        {
            jobService = _jobService;
        }

        /// <summary>
        /// This action gets all job adverts basic information.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await jobService.AllJobsAsync();

            return View(model);
        }
    }
}
