using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomsController : Controller
    {
        private IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 18)
        {
            return View(_roomService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int roomId)
        {
            return View(_roomService.GetRoomById(roomId));
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel room)
        {
            _roomService.UpdateRoomInfo(room);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomViewModel room)
        {
            _roomService.InsertRoomInfo(room);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int roomId)
        {
            _roomService.DeleteRoomInfo(roomId);
            return RedirectToAction("Index");
        }
    }
}