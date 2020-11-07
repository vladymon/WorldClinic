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

        public ICollection<MedicalAppointment> MedicalAppointments { get; set; }

        public City City { get; set; }

        //public ICollection<Department> Departments { get; set; }

        //[DisplayName("# de Departamentos")]
        //public int DepartmentsNumber => Departments == null ? 0 : Departments.Count;
    }
}
