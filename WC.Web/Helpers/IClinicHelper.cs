using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;
using WC.Web.Models;

namespace WC.Web.Helpers
{
    public interface IClinicHelper
    {
        Task<Clinic> AddUserAsync(AddClinicViewModel model, Guid imageId);
    }
}
