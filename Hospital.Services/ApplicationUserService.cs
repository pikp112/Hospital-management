using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            var vmList = new List<ApplicationUserViewModel>();

            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.Repository<ApplicationUser>().GetAll().Skip(excludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.Repository<ApplicationUserViewModel>().GetAll().Count();

                vmList = ConvertModelToViewModel(modelList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModel(List<ApplicationUser> modelList)
        {
            return modelList.Select(model => new ApplicationUserViewModel(model)).ToList();
        }

        public PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string specility = null)
        {
            throw new NotImplementedException();
        }
    }
}