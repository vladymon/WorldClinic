using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WC.Web.Models
{
    public class EditClinicViewModel
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe contener menos de {1} carateres ")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener menos de {1} carateres ")]
        public string Address { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [Display(Name = "Imagen")]
        public Guid ImageId { get; set; }

        [Display(Name = "Imagen")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://worldclinics.azurewebsites.net/images/noimage.png"
            : $"https://worldclinics.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }

        [Required]
        [Display(Name = "Pais")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un País")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [Required]
        [Display(Name = "Departmento")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un departamento.")]
        public int DepartmentId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city.")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
