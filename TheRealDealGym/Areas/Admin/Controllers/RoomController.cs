using Microsoft.AspNetCore.Mvc;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    public class RoomController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
