using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WC.Common.Entities
{
    public class MedicalAppointmentStatus
    {
        public int Id { get; set; }

        [DisplayName("Estado de la cita")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener menos de {1} carateres ")]
        [Required]
        public string Name { get; set; }

        public ICollection<MedicalAppointment> MedicalAppointments { get; set; }
    }
}
