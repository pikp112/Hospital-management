using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public interface IHospitalInfoService
    {
        PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);

        HospitalInfoViewModel GetHospitalById(int hospitalId);

        void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo);

        void InsetHospitalInfo(HospitalInfoViewModel hospitalInfo);

        void DeleteHospitalInfo(int hospitalId);
    }
}