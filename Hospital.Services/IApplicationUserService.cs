using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);

        PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize);

        PagedResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize);

        PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string specility = null);
    }
}