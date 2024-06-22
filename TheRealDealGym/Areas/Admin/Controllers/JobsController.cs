using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    public class JobsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
