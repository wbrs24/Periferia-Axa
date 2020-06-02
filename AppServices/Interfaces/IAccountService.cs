using DataAccess.Model.ViewModels;
using DataAccess.Model.ViewModels.AccountViewModel;
using DataAccess.Model.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Interfaces
{
    public interface IAccountService
    {
        ServiceResult Login(LoginViewModel lvm);
        ServiceResult Register(RegisterViewModel rvm);
    }
}
