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
            return View();
        }

        
        public IActionResult Login(UserViewModel userviewmodel)
        {
            
            UserDAL userdal = new UserDAL();
            User user = new User(userdal);
            if(userviewmodel.password != null || userviewmodel.Email != null)
            {
                if (user.CheckLogin(userviewmodel.Email, userviewmodel.password) == true) 
                {
                    HttpContext.Session.SetInt32("UserId", user.GetUserId(userviewmodel.Email));
                    return RedirectToAction("Index", "Home");
                }
            }


            return RedirectToAction("Index", "User");
        }
    }
}
