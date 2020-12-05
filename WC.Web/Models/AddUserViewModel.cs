using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WC.Web.Models
{
    public class AddUserViewModel : EditUserViewModel
    {
        [Display(Name = "Correo")]
        [Required(ErrorMessage = Startup.messageRequired)]
        [MaxLength(100, ErrorMessage = Startup.messageMaxLength)]
        [EmailAddress]
        public string Username { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = Startup.messageRequired)]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = Startup.messagePassword)]
        public string Password { get; set; }

        [Display(Name = "Confirmar contraseña")]
        [Required(ErrorMessage = Startup.messageRequired)]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = Startup.messagePassword)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }

}

