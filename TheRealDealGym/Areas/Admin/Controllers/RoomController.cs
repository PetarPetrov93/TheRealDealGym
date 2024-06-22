using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    public class RoomController : AdminBaseController
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService _roomService)
        {
            roomService = _roomService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await roomService.AllRoomsAsync();

            return View(model);
        }
    }
}
