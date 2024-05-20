using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public interface IRoomService
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);

        RoomViewModel GetRoomById(int roomId);

        void UpdateRoomInfo(RoomViewModel room);

        void InsertRoomInfo(RoomViewModel room);

        void DeleteRoomInfo(int roomId);
    }
}