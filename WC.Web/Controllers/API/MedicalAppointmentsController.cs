using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WC.Common.Entities;
using WC.Common.Requests;
using WC.Common.Responses;
using WC.Web.Data;
using WC.Web.Data.Entities;
using WC.Web.Helpers;

namespace WC.Web.Controllers.API
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class MedicalAppointmentsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public MedicalAppointmentsController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult GetMedicalAppointments()
        {
            return Ok(_context.MedicalAppointments.Include(c => c.Doctor));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> PostMedicalAppointment([FromBody] MedicalAppointmentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Bad request",
                    Result = ModelState
                });

            }
            string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Usuario no encontrado"
                });

            }
            Doctor doctor = await _context.Doctors.FindAsync(request.DoctorId);
            if (doctor == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "No existe el doctor"
                });
            }
            Clinic clinic = await _context.Clinics.FindAsync(request.ClinicId);
            if (clinic == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "No existe la clínica"
                });
            }
            Speciality speciality = await _context.Specialities.FindAsync(request.SpecialityId);
            if (speciality == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "No existe la especialidad"
                });
            }
            MedicalAppointmentStatus medicalAppointmentStatus = await _context.MedicalAppointmentStatus.FindAsync(request.MedicalAppointmentStatusId);
            if (medicalAppointmentStatus == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "No existe el estado"
                });
            }
            PaymentType paymentType = await _context.PaymentTypes.FindAsync(request.PaymentTypeId);
            if (paymentType == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "No existe el tipo de pago"
                });
            }

            ServiceType serviceType = await _context.ServiceTypes.FindAsync(request.ServiceTypeId);
            if (serviceType == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "No existe el tipo de servicio"
                });
            }

            Guid imageId = Guid.Empty;
            MedicalAppointment medicalAppointment = new MedicalAppointment
            {
                CreateDate = request.CreateDate,
                ConfirmationDate = request.ConfirmationDate,
                CancelDate = request.CancelDate,
                Price = request.Price,
                IdUser = request.IdUser,
                Doctor = doctor,
                Clinic = clinic,
                Speciality = speciality,
                MedicalAppointmentStatus = medicalAppointmentStatus,
                PaymentType = paymentType,
                ServiceType = serviceType
            };
            _context.MedicalAppointments.Add(medicalAppointment);
            await _context.SaveChangesAsync();
            return Ok(new Response { IsSuccess = true });
        }
    }
}
