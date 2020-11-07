using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WC.Common.Entities
{
    public class Speciality
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Imagen")]
        public Guid ImageId { get; set; }


        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://worldclinic.azurewebsites.net/images/noimage.png"
            : $"https://worldclinic.blob.core.windows.net/specialities/{ImageId}";

        public ICollection<MedicalAppointment> MedicalAppointments { get; set; }
    }
}
