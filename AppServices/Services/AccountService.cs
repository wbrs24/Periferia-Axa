using AppServices.Interfaces;
using AppUtilities;
using DataAccess.Interfaces;
using DataAccess.Model.ViewModels.AccountViewModel;
using DataAccess.Model.ViewModels.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly IUtilities _utilities;
        private ServiceResult _sr;
        public AccountService(IAccountRepository repository, IUtilities utilities)
        {
            _repo = repository;
            _utilities = utilities;
        }

        public ServiceResult Login(LoginViewModel lvm)
        {
            _sr = new ServiceResult() { IsValid = true, Error = new ServiceError() };
            var pass = _utilities.CreateMD5Hash(lvm.Password);
            var user = _repo.Login(lvm.Email.ToLower(), pass);
            if (user == null) {
                _sr.IsValid = false;
                _sr.Error.ErrorMessage = "¡Incorrect user or password!";
                return _sr;
            }
            _sr.ContentResult = JsonConvert.SerializeObject(user);
            return _sr;
        }
        public ServiceResult Register(RegisterViewModel rvm)
        {
            _sr = new ServiceResult() { IsValid = true, Error = new ServiceError() };
            var pass = _utilities.CreateMD5Hash(rvm.Password);
            rvm.Password = pass;
            var user = _repo.Register(rvm);
            if (user == null)
            {
                _sr.IsValid = false;
                _sr.Error.ErrorMessage = "¡The user cannot be created!";
                return _sr;
            }
            _sr.ContentResult = JsonConvert.SerializeObject(user);
            return _sr;
        }
    }
}