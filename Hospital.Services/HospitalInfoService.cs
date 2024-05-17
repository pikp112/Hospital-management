using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public class HospitalInfoService(IUnitOfWork unitOfWork) : IHospitalInfoService
    {
        public PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            var hospitalInfoViewModel = new HospitalInfoViewModel();
            int totalCount;
            var viewModelList = new List<HospitalInfoViewModel>();

            try
            {
                int exludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = unitOfWork.Repository<HospitalInfo>()
                    .GetAll()
                    .Skip(exludeRecords)
                    .Take(pageSize)
                    .ToList();

                totalCount = unitOfWork.Repository<HospitalInfo>()
                    .GetAll()
                    .Count;

                viewModelList = ConvertModelsToViewModels(modelList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var result = new PagedResult<HospitalInfoViewModel>
            {
                Data = viewModelList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private static List<HospitalInfoViewModel> ConvertModelsToViewModels(List<HospitalInfo> modelList)
        {
            return modelList.Select(model => new HospitalInfoViewModel(model)).ToList();
        }

        public HospitalInfoViewModel GetHospitalById(int hospitalId)
        {
            return new HospitalInfoViewModel(unitOfWork.Repository<HospitalInfo>()
                               .GetById(hospitalId));
        }

        public void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel()
                .ConvertViewModel(hospitalInfo);

            var modelById = unitOfWork.Repository<HospitalInfo>()
                .GetById(model.Id);

            modelById.Name = hospitalInfo.Name;
            modelById.Type = hospitalInfo.Type;
            modelById.City = hospitalInfo.City;
            modelById.PinCode = hospitalInfo.PinCode;
            modelById.Country = hospitalInfo.Country;

            unitOfWork.Repository<HospitalInfo>()
                .Update(modelById);

            unitOfWork.Save();
        }

        public void InsetHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel()
                .ConvertViewModel(hospitalInfo);

            unitOfWork.Repository<HospitalInfo>()
                .Add(model);

            unitOfWork.Save();
        }

        public void DeleteHospitalInfo(int hospitalId)
        {
            var model = unitOfWork.Repository<HospitalInfo>()
                .GetById(hospitalId);

            unitOfWork.Repository<HospitalInfo>()
                .Delete(model);

            unitOfWork.Save();
        }
    }
}