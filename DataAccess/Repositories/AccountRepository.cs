using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Model;
using DataAccess.Model.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMapper _mapper;
        private AxaTestEntities _dbContext;
        public AccountRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public LoggedUserViewModel Login(string email, string pass)
        {
            LoggedUserViewModel luvm = new LoggedUserViewModel();
            using (_dbContext = new AxaTestEntities())
            {
                var user = (from us in _dbContext.Users
                            where us.Email.Equals(email) && us.Password.Equals(pass)
                            select us).FirstOrDefault();
                
                luvm = _mapper.Map<User, LoggedUserViewModel>(user);
            }
            return luvm;
        }

        public LoggedUserViewModel Register(RegisterViewModel rvm)
        {
            LoggedUserViewModel luvm = new LoggedUserViewModel();
            var user = _mapper.Map<RegisterViewModel, User>(rvm);
            user.CreationDate = DateTime.Now;
            user.State = true;

            using (_dbContext = new AxaTestEntities())
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                if (user.IdUser != 0) {
                    var u = _dbContext.Users.Where(x=>x.IdUser == user.IdUser).FirstOrDefault();
                    luvm = _mapper.Map<User, LoggedUserViewModel>(u); }
                else { luvm = null; }
            }
            return luvm;
        }
    }
}
