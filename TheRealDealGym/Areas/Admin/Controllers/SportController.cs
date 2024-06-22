using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    /// <summary>
    /// Responisble for the page with the list of all sports.
    /// only an admin can add and remove sports.
    /// </summary>
    public class SportController : AdminBaseController
    {
        private readonly ISportService sportService;

        public SportController(ISportService _sportService)
        {
            sportService = _sportService;
        }

        /// <summary>
        /// This action gets all sports names.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await sportService.AllSportsAsync();

            return View(model);
        }
    }
}
