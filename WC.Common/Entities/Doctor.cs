using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WC.Common.Entities
{
    public class Doctor
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Apellidos")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Teléfono")]
        [MaxLength(50)]
        public string Phone { get; set; }

        [DisplayName("Correo")]
        [MaxLength(50)]
        public string Mail { get; set; }

        [DisplayName("Dirección")]
        [MaxLength(50)]
        public string Address { get; set; }

        public Speciality Speciality { get; set; }

        public ICollection<DoctorImage> DoctorImages { get; set; }

        [DisplayName("# Imagen")]
        public int DoctorImagesNumber => DoctorImages == null ? 0 : DoctorImages.Count;


        [Display(Name = "Imagen")]
        public string ImageFullPath => DoctorImages == null || DoctorImages.Count == 0
            ? $"https://worldclinic.azurewebsites.net/images/noimage.png"
            : DoctorImages.FirstOrDefault().ImageFullPath;

        public ICollection<MedicalAppointment> MedicalAppointments { get; set; }

    }
}
