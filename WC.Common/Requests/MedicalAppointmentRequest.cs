using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WC.Common.Entities;

namespace WC.Common.Requests
{
    public class MedicalAppointmentRequest
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime ConfirmationDate { get; set; }

        public DateTime CancelDate { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public float Price { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int ClinicId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int SpecialityId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int MedicalAppointmentStatusId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int PaymentTypeId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int ServiceTypeId { get; set; }
    }
}
