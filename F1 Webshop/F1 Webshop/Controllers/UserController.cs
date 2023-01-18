using DAL;
using F1_Webshop.Models;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace F1_Webshop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel viewModel = new();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                UserDAL userdal = new UserDAL();
                User user = new User(userdal);
                if (userviewmodel.password != null && userviewmodel.Email != null)
                {
                    if (user.CheckLogin(userviewmodel.Email, userviewmodel.password) == true)
                    {
                        HttpContext.Session.SetInt32("UserId", user.GetUserId(userviewmodel.Email));
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Incorrect password or username.");
                        return View();
                    }
                }               
            }
            return View();  
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(UserViewModel viewmodel)
        {
            UserDAL userdal = new UserDAL();
            UserCollection usercollection = new(userdal);
            if(viewmodel.Name != null && viewmodel.Email != null && viewmodel.password != null)
            {
                usercollection.CreateAccount(viewmodel.Name, viewmodel.Email, viewmodel.password);
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("password", "Every field needs to be filled in");
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }
    }

}