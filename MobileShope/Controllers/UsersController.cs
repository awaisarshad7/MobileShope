using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShope.Models;

namespace MobileShope.Controllers
{
    public class UsersController : Controller
    {
        MOBILESHOPFLOWContext OurDbContext = null;
        public UsersController(MOBILESHOPFLOWContext _OurDbContext)
        {
            OurDbContext = _OurDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddUsers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUsers(UserRegistration obj)
        {
            OurDbContext.UserRegistration.Add(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(UsersController.UsersList));
        }
        public IActionResult UsersList()
        {
            return View(OurDbContext.UserRegistration.ToList<UserRegistration>());
        }
        public IActionResult UsersDetail(int UsersID)
        {
            UserRegistration obj = OurDbContext.UserRegistration.Where(abc => abc.UserId == UsersID).FirstOrDefault();
            return View(obj);
        }
        public IActionResult UserDelete(int UsersID)
        {
            UserRegistration obj = OurDbContext.UserRegistration.Where(abc => abc.UserId == UsersID).FirstOrDefault();
            OurDbContext.UserRegistration.Remove(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(UsersController.UsersList));
        }
        [HttpGet]
        public IActionResult UserEdit(int UsersID)
        {
            UserRegistration obj = OurDbContext.UserRegistration.Where(abc => abc.UserId == UsersID).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public IActionResult UserEdit(UserRegistration obj)
        {
            OurDbContext.UserRegistration.Update(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(UsersController.UsersList));
        }
        public IActionResult NewLogin()
        {
            return View();
        }
        public IActionResult CheckLoginusingform(string username , string password)
        {
            UserRegistration obj = OurDbContext.UserRegistration.Where(abc => abc.Name == username).FirstOrDefault<UserRegistration>();
            if(obj.Password == password)
            {
                return RedirectToAction("DashBoard", "DashBoard");
            }
            else
            {
                return View();
            }
        }
    }
}