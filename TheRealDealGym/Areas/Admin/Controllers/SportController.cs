using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Sport;
using static TheRealDealGym.Core.Constants.MessageConstants;

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
        public async Task<IActionResult> Add(SportInfoModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            Guid newSport = await sportService.CreateAsync(model);

            TempData[MessageSuccess] = "You have successfully added a new sport!";
            return RedirectToAction(nameof(Index), "Sport");
        }

        /// <summary>
        /// This method returns a form, pre-filled with the information of the sport the admin wants to edit.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid sportId)
        {
            if (await sportService.ExistsByIdAsync(sportId) == false)
            {
                return BadRequest();
            }

            var model = await sportService.GetByIdAsync(sportId);

            return View(model);
        }

        /// <summary>
        /// This method handles the editted information from the admin and saves the changes.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(Guid sportId, SportInfoModel model)
        {
            if (await sportService.ExistsByIdAsync(sportId) == false)
            {
                return BadRequest();
            }
            if (ModelState.IsValid == false)
            {

                return View(model);
            }

            await sportService.EditAsync(sportId, model);

            TempData[MessageWarning] = "You have successfully edited this sport!";
            return RedirectToAction(nameof(Index), "Sport");
        }

        /// <summary>
        /// This method deteles the given sport.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(Guid sportId)
        {
            if (await sportService.ExistsByIdAsync(sportId) == false)
            {
                return BadRequest();
            }

            await sportService.DeleteAsync(sportId);

            TempData[MessageError] = "You have successfully deleted this sport!";
            return RedirectToAction(nameof(Index), "Sport");
        }
    }
}
