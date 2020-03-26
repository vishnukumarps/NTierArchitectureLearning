using BLL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SecuredLoginSystem
{
    public class HomeController : Controller
    {

        UserLogic user = new UserLogic();
        public HomeController()
        {
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
        public async Task<IActionResult> LoginPage(string Email,string Password,string Key)
        {
            var result = await user.Login(Email,Password,Key);
            if(result==true)
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
        public async Task<IActionResult> ReadData(User model)
        {
           var result=  await user.AddAsync(model);
            if(result==true)
            {
                return RedirectToAction("Success", "Home", new { msg = "Success" });
            }

            return RedirectToAction("Fail", "Home", new { msg = "Success" });
        }
    }
}
