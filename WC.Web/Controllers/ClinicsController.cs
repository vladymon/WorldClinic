using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;
using WC.Web.Data;
using WC.Web.Helpers;
using WC.Web.Models;

namespace WC.Web.Controllers
{
    public class ClinicsController : Controller
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly ICombosHelper _combosHelper;
        //private readonly IConverterHelper _converterHelper;
        private readonly IClinicHelper _clinicHelper;

        public ClinicsController(DataContext context, IClinicHelper clinicHelper, ICombosHelper combosHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _clinicHelper = clinicHelper;
            _combosHelper = combosHelper;
            _blobHelper = blobHelper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clinics.Include(c => c.City).ToListAsync());

        }
        public IActionResult Register()
        {
            AddClinicViewModel model = new AddClinicViewModel
            {
                Countries = _combosHelper.GetComboCountries(),
                Departments = _combosHelper.GetComboDepartments(0),
                Cities = _combosHelper.GetComboCities(0),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddClinicViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "clinics");
                }

                Clinic clinic = await _clinicHelper.AddUserAsync(model, imageId);
                if (clinic == null)
                {
                    ModelState.AddModelError(string.Empty, Startup.messageDuplicate);
                    model.Countries = _combosHelper.GetComboCountries();
                    model.Departments = _combosHelper.GetComboDepartments(model.CountryId);
                    model.Cities = _combosHelper.GetComboCities(model.DepartmentId);
                    return View(model);
                }
                return RedirectToAction("Index", "Clinics");

            }

            model.Countries = _combosHelper.GetComboCountries();
            model.Departments = _combosHelper.GetComboDepartments(model.CountryId);
            model.Cities = _combosHelper.GetComboCities(model.DepartmentId);
            return View(model);
        }


        public JsonResult GetDepartments(int countryId)
        {
            Country country = _context.Countries.Include(c => c.Departments).FirstOrDefault(c => c.Id == countryId);
            if (country == null)
            {
                return null;
            }
            return Json(country.Departments.OrderBy(d => d.Name));
        }

        public JsonResult GetCities(int departmentId)
        {
            Department department = _context.Departments.Include(d => d.Cities).FirstOrDefault(d => d.Id == departmentId);
            if (department == null)
            {
                return null;
            }
            return Json(department.Cities.OrderBy(c => c.Name));
        }

    }
}
