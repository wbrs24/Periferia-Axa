using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.ViewModels.AccountViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Número de Identificación")]
        public int IdNumber { get; set; }

        [Required]
        [Display(Name = "Tipo de Identificación")]
        public string IdType { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string SureName { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public string BirthDate { get; set; }

        [Required]
        [Display(Name = "Numbero de Contacto")]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
