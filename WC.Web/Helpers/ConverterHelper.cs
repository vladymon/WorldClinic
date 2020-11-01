using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;
using WC.Web.Data;
using WC.Web.Models;

namespace WC.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        public Speciality ToSpeciality(SpecialityViewModel model, Guid imageId, bool isNew)
        {
            return new Speciality
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                Name = model.Name
            };

        }

        public SpecialityViewModel ToSpecialityViewModel(Speciality speciality)
        {
            return new SpecialityViewModel
            {
                Id = speciality.Id,
                ImageId = speciality.ImageId,
                Name = speciality.Name
            };

        }
        public async Task<Doctor> ToDoctorAsync(DoctorViewModel model, bool isNew)
        {
            return new Doctor
            {
                Speciality = await _context.Specialities.FindAsync(model.SpecialityId),
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                DoctorImages = model.DoctorImages
            };

        }

        public DoctorViewModel ToDoctorViewModel(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
