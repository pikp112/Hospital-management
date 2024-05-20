using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteContact(int contactId)
        {
            var model = _unitOfWork.Repository<Contact>().GetById(contactId);
            _unitOfWork.Repository<Contact>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ContactViewModel();
            int totalCount;
            var vmList = new List<ContactViewModel>();

            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.Repository<Contact>().GetAll(includProperties: "Hospital").Skip(excludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.Repository<Contact>().GetAll().Count();

                vmList = ConvertModelToViewModel(modelList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new PagedResult<ContactViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        private List<ContactViewModel> ConvertModelToViewModel(List<Contact> modelList)
        {
            return modelList.Select(model => new ContactViewModel(model)).ToList();
        }

        public ContactViewModel GetContactById(int contactId)
        {
            var model = _unitOfWork.Repository<Contact>().GetById(contactId);
            var vm = new ContactViewModel(model);
            return vm;
        }

        public void InsertContact(ContactViewModel contact)
        {
            var model = _unitOfWork.Repository<Contact>().GetById(contact.Id);
            _unitOfWork.Repository<Contact>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(contact);
            var modelById = _unitOfWork.Repository<Contact>().GetById(contact.Id);
            modelById.Phone = contact.Phone;
            modelById.Email = contact.Email;
            modelById.HospitalId = contact.HospitalInfoId;

            _unitOfWork.Repository<Contact>().Update(modelById);
            _unitOfWork.Save();
        }
    }
}