using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheRealDealGym.Attributes;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Class;
using TheRealDealGym.Core.Models.Room;
using TheRealDealGym.Core.Services;

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

        /// <summary>
        /// This method returns a form to fill in order to add a new room.
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// This method handles the input infromation from the form and creates a new room.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(RoomServiceModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            Guid newRoom = await roomService.CreateAsync(model);
            return RedirectToAction(nameof(Index), "Room");
        }

        /// <summary>
        /// This method returns a form, pre-filled with the information of the room the admin wants to edit.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid roomId)
        {
            if (await roomService.ExistsByIdAsync(roomId) == false)
            {
                return BadRequest();
            }

            var model = await roomService.GetRoomByIdAsync(roomId);

            return View(model);
        }

        /// <summary>
        /// This method handles the editted information from the admin and saves the changes.
        /// </summary>
        [HttpPost]
        [MustBeTrainer]
        public async Task<IActionResult> Edit(Guid roomId, RoomServiceModel model)
        {
            if (await roomService.ExistsByIdAsync(roomId) == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
               
                return View(model);
            }

            await roomService.EditAsync(roomId, model);

            return RedirectToAction(nameof(Index), "Room");
        }

        /// <summary>
        /// This method deteles the given room.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(Guid roomId)
        {
            if (await roomService.ExistsByIdAsync(roomId) == false)
            {
                return BadRequest();
            }

            await roomService.DeleteAsync(roomId);

            return RedirectToAction(nameof(Index), "Room");
        }
    }
}
