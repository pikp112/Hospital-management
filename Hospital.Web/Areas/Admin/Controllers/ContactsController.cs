using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactsController : Controller
    {
        private IContactService _contactService;
        private IHospitalInfoService _hospitalInfoService;

        public ContactsController(IContactService contactService, IHospitalInfoService hospitalInfoService)
        {
            _contactService = contactService;
            _hospitalInfoService = hospitalInfoService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 18)
        {
            return View(_contactService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int contactId)
        {
            ViewBag.hospital = new SelectList(_hospitalInfoService.GetAll(1, 100).Data, "HospitalId", "HospitalName");
            var viewModel = _contactService.GetContactById(contactId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ContactViewModel contact)
        {
            _contactService.UpdateContact(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel contact)
        {
            _contactService.InsertContact(contact);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int contactId)
        {
            _contactService.DeleteContact(contactId);
            return RedirectToAction("Index");
        }
    }
}