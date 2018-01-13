using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShope.Models;

namespace MobileShope.Controllers
{
    public class CustomerController : Controller
    {
        MOBILESHOPFLOWContext OurDbContext = null;
        public CustomerController(MOBILESHOPFLOWContext _OurDbContext)
        {
            OurDbContext = _OurDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customers obj)
        {
            OurDbContext.Customers.Add(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(CustomerController.CustomersList));
        }
        public IActionResult CustomersList()
        {
            return View(OurDbContext.Customers.ToList<Customers>());
        }
        public IActionResult CustomerDetail(int CustomerID)
        {
          Customers cu = OurDbContext.Customers.Where(abc => abc.CustomerId == CustomerID).FirstOrDefault();
            return View(cu);
        }
        public IActionResult CustomerDelete(Customers cu)
        {
            OurDbContext.Customers.Remove(cu);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(CustomerController.CustomersList));
        }
        [HttpGet]
        public IActionResult CustomerEdit(int CustomerID)
        {
            Customers cu = OurDbContext.Customers.Where(abc => abc.CustomerId == CustomerID).FirstOrDefault();
            return View(cu);
        }
        [HttpPost]
        public IActionResult CustomerEdit(Customers cu)
        {
            OurDbContext.Customers.Update(cu);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(CustomerController.CustomersList));
        }
    }
}