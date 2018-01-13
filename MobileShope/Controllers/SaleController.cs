using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShope.Models;

namespace MobileShope.Controllers
{
    public class SaleController : Controller
    {
        MOBILESHOPFLOWContext OurDbContext = null;
        public SaleController(MOBILESHOPFLOWContext _OurDbContext)
        {
            OurDbContext = _OurDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddSale()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSale(Sale obj)
        {
            OurDbContext.Sale.Add(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(SaleController.SaleList));
        }
        public IActionResult SaleList()
        {
            return View(OurDbContext.Sale.ToList<Sale>());
        }
        public IActionResult SaleDetail(int SaleID)
        {
            Sale obj = OurDbContext.Sale.Where(abc => abc.Id == SaleID).FirstOrDefault();
            return View(obj);
        }
        public IActionResult SaleDelete(int SaleID)
        {
            Sale obj = OurDbContext.Sale.Where(abc => abc.Id == SaleID).FirstOrDefault();
            OurDbContext.Sale.Remove(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(SaleController.SaleList));
        }
        [HttpGet]
        public IActionResult SaleEdit(int SaleID)
        {
            Sale obj = OurDbContext.Sale.Where(abc => abc.Id == SaleID).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public IActionResult SaleEdit(Sale obj)
        {
            OurDbContext.Sale.Update(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(SaleController.SaleList));
        }
    }
}