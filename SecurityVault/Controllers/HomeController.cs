using BLL;
using BLL.Interfaces;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SecurityVault.Web
{
    public class HomeController : Controller
    {

        //UserLogic user = new UserLogic();
        private readonly IUserBusinessService _userBusinessService;
        public HomeController(IUserBusinessService _userBusinessService)
        {
            this._userBusinessService = _userBusinessService;
        }

        public IActionResult Index(string msg)
        {
          
            return View(msg);
        }

        public IActionResult Fail()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email,string Password,string Key)
        {
            var result = await _userBusinessService.Login(Email, Password, Key);
            if (result == true)
            {
                return RedirectToAction("Success", "Home");
            }


            return RedirectToAction("Fail", "Home");
        }

        public IActionResult Success(string msg)
        {

            return View(msg);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
        

            var result = await _userBusinessService.Add(newUser);
          
            if (result!=null)
            {
                return RedirectToAction("Success", "Home", new { msg = "Success" });
            }

            return RedirectToAction("Fail", "Home", new { msg = "Success" });
        }
    }
}
