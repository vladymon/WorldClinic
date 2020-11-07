using System;
using System.Collections.Generic;
using System.Text;

namespace WC.Common.Entities
{
    public class MedicalAppointment
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ConfirmationDate { get; set; }

        public DateTime CancelDate { get; set; }

        public float Price { get; set; }

        public int IdUser { get; set; }

        public Doctor Doctor { get; set; }

        public Clinic Clinic { get; set; }

        public Speciality Speciality { get; set; }

        public MedicalAppointmentStatus MedicalAppointmentStatus { get; set; }

        public PaymentType PaymentType { get; set; }

        public ServiceType ServiceType { get; set; }

    }
}
