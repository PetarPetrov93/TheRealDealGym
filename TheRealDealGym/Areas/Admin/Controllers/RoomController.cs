using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;

namespace TheRealDealGym.Areas.Admin.Controllers
{
    /// <summary>
    /// Responisble for the page with the list of all rooms.
    /// only an admin can add and remove rooms.
    /// </summary>
    public class RoomController : AdminBaseController
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService _roomService)
        {
            roomService = _roomService;
        }

        /// <summary>
        /// This action gets all rooms information.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await roomService.AllRoomsAsync();

            return View(model);
        }
    }
}
