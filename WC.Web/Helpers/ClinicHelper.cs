using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;
using WC.Web.Data;
using WC.Web.Models;

namespace WC.Web.Helpers
{
    public class ClinicHelper : IClinicHelper
    {
        private readonly DataContext _context;

        public ClinicHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<Clinic> AddUserAsync(AddClinicViewModel model, Guid imageId)
        {
            Clinic clinic = new Clinic
            {
                Name = model.Name,
                Address = model.Address,
                Longitude = model.Longitude,
                Latitude = model.Latitude,
                ImageId = imageId,
                City = await _context.Cities.FindAsync(model.CityId),
            };
            _context.Add(clinic);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return null;
            }
            return clinic;
        }

    }
}
