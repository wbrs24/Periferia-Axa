using AppServices.Interfaces;
using DataAccess.Model.ViewModels.AccountViewModel;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AxaAssistance.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) {
            _accountService = accountService;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var result = _accountService.Login(loginModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            return View("Home/Index");
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var result = _accountService.Register(registerModel);
            return Json(result);
        }
    }
}