using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WC.Common.Entities
{
    public class Clinic
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe contener menos de {1} carateres ")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener menos de {1} carateres ")]
        public string Address { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Display(Name = "Imagen")]
        public Guid ImageId { get; set; }

        [Display(Name = "Imagen")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://worldclinics.azurewebsites.net/images/noimage.png"
            : $"https://worldclinics.blob.core.windows.net/clinics/{ImageId}";

        public ICollection<MedicalAppointment> MedicalAppointments { get; set; }
        [Required]
        public City City { get; set; }

        //public ICollection<Department> Departments { get; set; }

        //[DisplayName("# de Departamentos")]
        //public int DepartmentsNumber => Departments == null ? 0 : Departments.Count;
    }
}
