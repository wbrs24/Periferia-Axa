using DataAccess.Model.ViewModels;
using DataAccess.Model.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        LoggedUserViewModel Login(string email, string pass);
        LoggedUserViewModel Register(RegisterViewModel rvm);
    }
}
