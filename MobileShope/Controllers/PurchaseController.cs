using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShope.Models;

namespace MobileShope.Controllers
{
    public class PurchaseController : Controller
    {
        MOBILESHOPFLOWContext OurDbContext = null;
        public PurchaseController(MOBILESHOPFLOWContext _OurDbContext)
        {
            OurDbContext = _OurDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddPurchase()
        {
            IList<Vendor> vnList = OurDbContext.Vendor.ToList<Vendor>();
            ViewBag.Vendor = vnList;
            IList<Items> itList = OurDbContext.Items.ToList<Items>();
            ViewBag.item = itList;
            return View();
        }
        [HttpPost]
        public IActionResult AddPurchase(Purchase obj)
        {
            OurDbContext.Purchase.Add(obj);
            OurDbContext.SaveChanges();
            IList<Vendor> vnList = OurDbContext.Vendor.ToList<Vendor>();
            ViewBag.vendor = vnList;
            IList<Items> itList = OurDbContext.Items.ToList<Items>();
            ViewBag.item = itList;
            return RedirectToAction(nameof(PurchaseList));
        }
        public IActionResult PurchaseList()
        {
            return View(OurDbContext.Purchase.ToList<Purchase>());
        }
        public IActionResult PurchaseDetail(int PurchaseID)
        {
            Purchase obj  = OurDbContext.Purchase.Where(abc => abc.Id == PurchaseID).FirstOrDefault();            
            return View(obj);
        }
        public IActionResult PurchaseDelete(int PurchaseID )
        {
            Purchase obj = OurDbContext.Purchase.Where(abc => abc.Id == PurchaseID).FirstOrDefault();
            OurDbContext.Purchase.Remove(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(PurchaseController.PurchaseList));
        }
        [HttpGet]
        public IActionResult PurchaseEdit(int PurchaseID)
        {
            Purchase obj = OurDbContext.Purchase.Where(abc => abc.Id == PurchaseID).FirstOrDefault();

            return View(obj);
        }
        [HttpPost]
        public IActionResult PurchaseEdit(Purchase obj)
        {
            OurDbContext.Purchase.Update(obj);
            OurDbContext.SaveChanges();


            return RedirectToAction(nameof(PurchaseController.PurchaseList));
        }
        public IActionResult PurchaseHistory()
        {
            return View(OurDbContext.Purchase.ToList<Purchase>());
        }
    }
}