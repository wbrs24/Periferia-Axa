using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.ViewModels.AccountViewModel
{
    public class RolViewModel
    {
        public int IdRol { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string Description { get; set; }
    }
}
