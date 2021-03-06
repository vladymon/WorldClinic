﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WC.Common.Entities
{
    public class MedicalAppointment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime ConfirmationDate { get; set; }

        public DateTime CancelDate { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public float Price { get; set; }

        public int IdUser { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public Doctor Doctor { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public Clinic Clinic { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public Speciality Speciality { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public MedicalAppointmentStatus MedicalAppointmentStatus { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public PaymentType PaymentType { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public ServiceType ServiceType { get; set; }

    }
}
