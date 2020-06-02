using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.ViewModels.AccountViewModel
{
    public class LoggedUserViewModel
    {
        public int IdUser { get; set; }
        [Display(Name = "Identification Number")]
        public int IdNumber { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Surename")]
        public string SureName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public bool State { get; set; }
        [Display(Name = "Rols")]
        public IEnumerable<RolViewModel> Rols { get; set; }
    }
}
