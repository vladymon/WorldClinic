using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WC.Common.Entities;
using WC.Common.Responses;
using WC.Web.Data;
using WC.Web.Data.Entities;
using WC.Web.Helpers;

namespace WC.Web.Controllers.API
{

    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class SpecialitiesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SpecialitiesController(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> PostSpeciality([FromBody] SpecialityResponse request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                return NotFound("Error001");
            }
            Guid imageId = Guid.Empty;
            Speciality speciality = new Speciality
            {
                Name = request.Name,
                ImageId = imageId,
                
            };
            _context.Specialities.Add(speciality);
            await _context.SaveChangesAsync();
            return Ok(new Response { IsSuccess = true });
        }        

    }

}
