using Hospital.Utilities;
using Hospital.ViewModels;

namespace Hospital.Services
{
    public interface IContactService
    {
        PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);

        ContactViewModel GetContactById(int contactId);

        void UpdateContact(ContactViewModel contact);

        void InsertContact(ContactViewModel contact);

        void DeleteContact(int contactId);
    }
}