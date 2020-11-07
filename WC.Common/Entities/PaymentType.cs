using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WC.Common.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }

        [DisplayName("Tipo de pago")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener menos de {1} carateres ")]
        [Required]
        public string Name { get; set; }

        public ICollection<MedicalAppointment> MedicalAppointments { get; set; }

    }
}
