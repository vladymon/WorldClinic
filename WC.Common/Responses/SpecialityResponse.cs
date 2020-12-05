using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WC.Common.Entities;

namespace WC.Common.Responses
{
    public class SpecialityResponse
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid ImageId { get; set; }


        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://worldclinics.azurewebsites.net/images/noimage.png"
            : $"https://worldclinics.blob.core.windows.net/specialities/{ImageId}";

        public ICollection<MedicalAppointment> MedicalAppointments { get; set; }
    }
}
