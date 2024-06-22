using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    public class SportController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
