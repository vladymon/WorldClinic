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
    public class ClinicsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public ClinicsController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult GetClinics()
        {
            return Ok(_context.Clinics.Include(c => c.City).ThenInclude(d => d.Department).ThenInclude(s => s.Country));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> PostClinic([FromBody] ClinicRequest request)
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
            City city = await _context.Cities.FindAsync(request.CityId);
            if (city == null)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "No existe la ciudad"
                });
            }

            Guid imageId = Guid.Empty;
            Clinic clinic = new Clinic
            {
                Name = request.Name,
                Address = request.Address,
                Longitude= request.Longitude,
                Latitude = request.Latitude,                
                City = city
            };
            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();
            return Ok(new Response { IsSuccess = true });
        }
    }
}
