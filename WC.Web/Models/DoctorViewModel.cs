using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;

namespace WC.Web.Models
{
    public class DoctorViewModel : Doctor
    {
        [Display(Name = "Especialidad")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a category.")]
        [Required]
        public int SpecialityId { get; set; }

        public IEnumerable<SelectListItem> Specialities { get; set; }
    }

}
