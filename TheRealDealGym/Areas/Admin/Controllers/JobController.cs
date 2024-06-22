using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    public class JobController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
