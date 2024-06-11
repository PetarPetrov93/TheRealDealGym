using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Controllers
{
    /// <summary>
    /// Responisble for the page with the list of all classes.
    /// a registered non-trainer user can book class, view details and cancel class.
    /// a trainer can view all classes, add class, edit and remove his own classes.
    /// </summary>
    public class ClassController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
