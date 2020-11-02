using Microsoft.AspNetCore.Http;
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
        [Range(1, int.MaxValue, ErrorMessage = Startup.messageSelectItem)]
        [Required]
        public int SpecialityId { get; set; }

        public IEnumerable<SelectListItem> Specialities { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }

}
