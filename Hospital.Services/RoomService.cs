using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModels;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoomInfo(int roomId)
        {
            var model = _unitOfWork.Repository<Room>().GetById(roomId);
            _unitOfWork.Repository<Room>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new RoomViewModel();
            int totalCount;
            var vmList = new List<RoomViewModel>();
            try
            {
                int excludeProperties = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.Repository<Room>().GetAll(includProperties: "Hospital").Skip(excludeProperties).Take(pageSize).ToList();
                totalCount = _unitOfWork.Repository<Room>().GetAll().Count();

                vmList = ConvertModelToViewModel(modelList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new PagedResult<RoomViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        private static List<RoomViewModel> ConvertModelToViewModel(List<Room> modelList)
        {
            return modelList.Select(model => new RoomViewModel(model)).ToList();
        }

        public RoomViewModel GetRoomById(int hospitalId)
        {
            var model = _unitOfWork.Repository<Room>().GetById(hospitalId);
            var vm = new RoomViewModel(model);
            return vm;
        }

        public void InsertRoomInfo(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertViewModel(room);
            _unitOfWork.Repository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoomInfo(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertViewModel(room);
            var modelById = _unitOfWork.Repository<Room>().GetById(model.Id);
            modelById.Type = room.Type;
            modelById.Number = room.RoomNumber;
            modelById.Status = room.Status;
            modelById.HospitalId = room.HospitalInfoId;

            _unitOfWork.Repository<Room>().Update(modelById);
            _unitOfWork.Save();
        }
    }
}