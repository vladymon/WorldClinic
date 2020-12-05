using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WC.Common.Entities
{
    public class DoctorImage
    {
        public int Id { get; set; }

        [Display(Name = "Imagen")]
        public Guid ImageId { get; set; }


        [Display(Name = "Imagen")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://worldclinics.azurewebsites.net/images/noimage.png"
            : $"https://worldclinics.blob.core.windows.net/doctors/{ImageId}";
    }
}
