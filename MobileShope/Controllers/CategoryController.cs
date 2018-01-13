using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShope.Models;

namespace MobileShope.Controllers
{
    public class CategoryController : Controller
    {
        MOBILESHOPFLOWContext OurdbContext = null;
        
        public CategoryController(MOBILESHOPFLOWContext _OurdbContext )
        {
            OurdbContext = _OurdbContext;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category ct)
        {
            OurdbContext.Category.Add(ct);
            OurdbContext.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public IActionResult CategoryList()
        {
            return View(OurdbContext.Category.ToList<Category>());
        }
        public IActionResult CategoryDetail(int CategoryID)
        {
            Category obj = OurdbContext.Category.Where(abc => abc.CategoryId == CategoryID).FirstOrDefault();
            return View(obj);
        }
        public IActionResult CategoryDelete(int CategoryID)
        {
            Category ct = OurdbContext.Category.Where(abc => abc.CategoryId == CategoryID).FirstOrDefault<Category>();
            OurdbContext.Category.Remove(ct);
            OurdbContext.SaveChanges();
            return RedirectToAction(nameof(CategoryController.CategoryList));
        }
        [HttpGet]
        public IActionResult CategoryEdit(int CategoryID)
        {
           Category ct = OurdbContext.Category.Where(abc => abc.CategoryId == CategoryID).FirstOrDefault();
            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category ct)
        {
            OurdbContext.Category.Update(ct);
            OurdbContext.SaveChanges();
            return RedirectToAction(nameof(CategoryController.CategoryList));
        }
    }
}