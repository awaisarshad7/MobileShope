using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShope.Models;

namespace MobileShope.Controllers
{
    public class DashBoardController : Controller
    {
        MOBILESHOPFLOWContext OurDbContext = null;
        public DashBoardController(MOBILESHOPFLOWContext _OurDbContext)
        {
            OurDbContext = _OurDbContext;
        }
       
        public IActionResult DashBoard()
        {
            return View();
        }
        public int CountCategory()
        {
            return OurDbContext.Category.ToList<Category>().Count;
        }
        public int CountItems()
        {
            return OurDbContext.Items.ToList<Items>().Count;
        }
        public int CountPurchase()
        {
            return OurDbContext.Purchase.ToList<Purchase>().Count;
        }
        public int CountSale()
        {
            return OurDbContext.Sale.ToList<Sale>().Count;
        }
        public int CountCustomers()
        {
            return OurDbContext.Customers.ToList<Customers>().Count;
        }
        public int CountVendors()
        {
            return OurDbContext.Vendor.ToList<Vendor>().Count;
        }
        public int CountUser()
        {
            return OurDbContext.UserRegistration.ToList<UserRegistration>().Count;
        }
       // public IActionResult Slider()
       // {
       //     return View();
       // }
       //public IActionResult AwaisSlider()
       // {
       //     return View();
       // }
    }
}