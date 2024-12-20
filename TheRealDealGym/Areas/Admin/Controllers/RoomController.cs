﻿using Microsoft.AspNetCore.Mvc;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Job;
using TheRealDealGym.Core.Models.Room;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data.Models;
using static TheRealDealGym.Core.Constants.MessageConstants;

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
        public async Task<IActionResult> Index([FromQuery] AllRoomsQueryModel model)
        {
            var rooms = await roomService.AllRoomsAsync(
                model.OrderBy,
                model.CurrentPage,
                model.RoomsPerPage);

            model.TotalRoomsCount = rooms.RoomsCount;
            model.Rooms = rooms.Rooms;

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

            TempData[MessageSuccess] = "You have successfully added a new room!";
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

            var model = await roomService.GetByIdAsync(roomId);

            return View(model);
        }

        /// <summary>
        /// This method handles the editted information from the admin and saves the changes.
        /// </summary>
        [HttpPost]
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

            try
            {
                await roomService.EditAsync(roomId, model);

                TempData[MessageWarning] = "You have successfully edited this room!";
                return RedirectToAction(nameof(Index), "Room");
            }
            catch (Exception ex)
            {
                TempData[MessageError] = ex.Message;
                return RedirectToAction(nameof(Index), "Room");
            }
            
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

            try
            {
                await roomService.DeleteAsync(roomId);

                TempData[MessageError] = "You have successfully deleted this room!";
                return RedirectToAction(nameof(Index), "Room");
            }
            catch (Exception ex)
            {
                TempData[MessageError] = ex.Message;
                return RedirectToAction(nameof(Index), "Room");
            }
        }
    }
}
