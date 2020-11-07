using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WC.Common.Entities;
using WC.Web.Data;

namespace WC.Web.Controllers
{
    public class MedicalAppointmentsController : Controller
    {
        private readonly DataContext _context;

        public MedicalAppointmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: MedicalAppointments
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalAppointments.ToListAsync());
        }

        // GET: MedicalAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalAppointment = await _context.MedicalAppointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalAppointment == null)
            {
                return NotFound();
            }

            return View(medicalAppointment);
        }

        // GET: MedicalAppointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalAppointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreateDate,ConfirmationDate,CancelDate,Price,IdUser")] MedicalAppointment medicalAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalAppointment);
        }

        // GET: MedicalAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalAppointment = await _context.MedicalAppointments.FindAsync(id);
            if (medicalAppointment == null)
            {
                return NotFound();
            }
            return View(medicalAppointment);
        }

        // POST: MedicalAppointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreateDate,ConfirmationDate,CancelDate,Price,IdUser")] MedicalAppointment medicalAppointment)
        {
            if (id != medicalAppointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalAppointmentExists(medicalAppointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicalAppointment);
        }

        // GET: MedicalAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalAppointment = await _context.MedicalAppointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalAppointment == null)
            {
                return NotFound();
            }

            return View(medicalAppointment);
        }

        // POST: MedicalAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalAppointment = await _context.MedicalAppointments.FindAsync(id);
            _context.MedicalAppointments.Remove(medicalAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalAppointmentExists(int id)
        {
            return _context.MedicalAppointments.Any(e => e.Id == id);
        }
    }
}
