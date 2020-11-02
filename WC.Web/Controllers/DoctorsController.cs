using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class DoctorsController : Controller
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public DoctorsController(DataContext context, IBlobHelper blobHelper, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _blobHelper = blobHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.Include(d => d.Speciality).Include(d => d.DoctorImages).ToListAsync());

        }
        public IActionResult Create()
        {
            DoctorViewModel model = new DoctorViewModel
            {
                Specialities = _combosHelper.GetComboSpecialities(),                
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Doctor doctor = await _converterHelper.ToDoctorAsync(model, true);

                    if (model.ImageFile != null)
                    {
                        Guid imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "doctors");
                        doctor.DoctorImages = new List<DoctorImage>
                        {
                            new DoctorImage { ImageId = imageId }
                        };
                    }
                    _context.Add(doctor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, Startup.messageDuplicate);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            model.Specialities = _combosHelper.GetComboSpecialities();
            return View(model);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors
                .Include(p => p.Speciality)
                .Include(p => p.DoctorImages)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            DoctorViewModel model = _converterHelper.ToDoctorViewModel(doctor);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Doctor doctor = await _converterHelper.ToDoctorAsync(model, false);

                    if (model.ImageFile != null)
                    {
                        Guid imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "doctors");
                        if (doctor.DoctorImages == null)
                        {
                            doctor.DoctorImages = new List<DoctorImage>();
                        }

                        doctor.DoctorImages.Add(new DoctorImage { ImageId = imageId });
                    }

                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, Startup.messageDuplicate);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            model.Specialities = _combosHelper.GetComboSpecialities();
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors
                .Include(p => p.DoctorImages)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            try
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors
                .Include(c => c.Speciality)
                .Include(c => c.DoctorImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        public async Task<IActionResult> AddImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            AddDoctorImageViewModel model = new AddDoctorImageViewModel { DoctorId = doctor.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(AddDoctorImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = await _context.Doctors
                    .Include(p => p.DoctorImages)
                    .FirstOrDefaultAsync(p => p.Id == model.DoctorId);
                if (doctor == null)
                {
                    return NotFound();
                }

                try
                {
                    Guid imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "doctors");
                    if (doctor.DoctorImages == null)
                    {
                        doctor.DoctorImages = new List<DoctorImage>();
                    }

                    doctor.DoctorImages.Add(new DoctorImage { ImageId = imageId });
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{doctor.Id}");

                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DoctorImage doctorImage = await _context.DoctorImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorImage == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(p => p.DoctorImages.FirstOrDefault(pi => pi.Id == doctorImage.Id) != null);
            _context.DoctorImages.Remove(doctorImage);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{doctor.Id}");
        }

    }
}
