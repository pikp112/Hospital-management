using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HospitalsController(IHospitalInfoService _hospitalInfoService) : Controller
    {
        public IActionResult Index(int pageNumber, int pageSize = 10)
        {
            return View(_hospitalInfoService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int hospitalId)
        {
            return View(_hospitalInfoService.GetHospitalById(hospitalId));
        }

        [HttpPost]
        public IActionResult Edit(HospitalInfoViewModel hospitalInfo)
        {
            _hospitalInfoService.UpdateHospitalInfo(hospitalInfo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HospitalInfoViewModel hospitalInfo)
        {
            _hospitalInfoService.InsetHospitalInfo(hospitalInfo);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int hospitalId)
        {
            _hospitalInfoService.DeleteHospitalInfo(hospitalId);
            return RedirectToAction("Index");
        }
    }
}