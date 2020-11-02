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
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
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
                LastName = model.LastName,
                Phone = model.Phone,
                Mail = model.Mail,
                Address = model.Address,
                DoctorImages = model.DoctorImages
            };

        }

        public DoctorViewModel ToDoctorViewModel(Doctor doctor)
        {
            return new DoctorViewModel
            {
                Specialities = _combosHelper.GetComboSpecialities(),
                Speciality = doctor.Speciality,
                SpecialityId = doctor.Speciality.Id,
                Name = doctor.Name,
                LastName = doctor.LastName,
                Phone = doctor.Phone,
                Mail = doctor.Mail,
                Address = doctor.Address,
                DoctorImages = doctor.DoctorImages,
            };
        }
    }
}
