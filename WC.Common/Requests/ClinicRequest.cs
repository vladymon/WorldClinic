using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WC.Common.Entities;

namespace WC.Common.Requests
{
    public class ClinicRequest
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public double Latitude { get; set; }

        public Guid ImageId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int CityId { get; set; }
    }
}
