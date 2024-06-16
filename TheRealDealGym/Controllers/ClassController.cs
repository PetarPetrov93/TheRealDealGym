using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Class;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Responisble for the page with the list of all classes.
    /// a registered non-trainer user can book class, view details and cancel class.
    /// a trainer can view all classes, add class, edit and remove his own classes.
    /// </summary>
    public class ClassController : BaseController
    {
        private readonly IClassService classService;

        public ClassController(IClassService _classService)
        {
            classService = _classService;
        }

        /// <summary>
        /// This action displays the list of all classes and implements a search and filter options.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllClassesQueryModel model)
        {
            var classes = await classService.AllAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.ClassesPerPage);

            model.TotalClassesCount = classes.TotalClassesCount;
            model.Classes = classes.Classes;
            model.Categories = await classService.AllSportCategoriesAsync();

            return View(model);
        }

        /// <summary>
        /// This action displays the full information about the class upon pressing the "Details" button.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }
    }
}
