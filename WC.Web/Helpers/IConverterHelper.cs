using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;
using WC.Web.Models;

namespace WC.Web.Helpers
{
    public interface IConverterHelper
    {
        Speciality ToSpeciality(SpecialityViewModel model, Guid imageId, bool isNew);
        SpecialityViewModel ToSpecialityViewModel(Speciality speciality);

        Task<Doctor> ToDoctorAsync(DoctorViewModel model, bool isNew);

        DoctorViewModel ToDoctorViewModel(Doctor doctor);

    }
}
