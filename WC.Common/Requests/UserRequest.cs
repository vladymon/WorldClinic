using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WC.Common.Requests
{
    public class UserRequest
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        public byte[] ImageArray { get; set; }
    }

}
