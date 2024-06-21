using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
