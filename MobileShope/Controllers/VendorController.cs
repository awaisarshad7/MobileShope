using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShope.Models;

namespace MobileShope.Controllers
{
    public class VendorController : Controller
    {
        MOBILESHOPFLOWContext OurDbContext = null;
        public VendorController(MOBILESHOPFLOWContext _OurDbContext)
        {
            OurDbContext = _OurDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddVendor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVendor(Vendor obj)
        {
            OurDbContext.Vendor.Add(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(VendorController.VendorList));
        }
        public IActionResult VendorList()
        {
            return View(OurDbContext.Vendor.ToList<Vendor>());
        }
        public IActionResult VendorDetail(int VendorID)
        {
            Vendor obj = OurDbContext.Vendor.Where(abc => abc.VendorId == VendorID).FirstOrDefault();
            return View(obj);
        }
        public IActionResult VendorDelete(int VendorID)
        {
            Vendor obj = OurDbContext.Vendor.Where(abc => abc.VendorId == VendorID).FirstOrDefault();
            OurDbContext.Vendor.Remove(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(VendorController.VendorList));
        }
        [HttpGet]
        public IActionResult VendorEdit(int VendorID)
        {
            Vendor obj = OurDbContext.Vendor.Where(abc => abc.VendorId == VendorID).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public IActionResult VendorEdit(Vendor obj)
        {
            OurDbContext.Vendor.Update(obj);
            OurDbContext.SaveChanges();
            return RedirectToAction(nameof(VendorController.VendorList));
        }
    }
}