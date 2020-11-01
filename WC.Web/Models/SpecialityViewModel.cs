using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WC.Common.Entities;

namespace WC.Web.Models
{
    public class SpecialityViewModel : Speciality
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
