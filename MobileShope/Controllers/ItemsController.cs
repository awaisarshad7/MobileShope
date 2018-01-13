using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShope.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MobileShope.Controllers
{
    public class ItemsController : Controller
    {
        MOBILESHOPFLOWContext OurDbContext = null;
        IHostingEnvironment env = null;

        public ItemsController(MOBILESHOPFLOWContext _OurDbcontext ,IHostingEnvironment _env)
        {
            OurDbContext = _OurDbcontext;
            env = _env;
        }
        public IActionResult Index()
        {           
            return View();
        }
        [HttpGet]
        public IActionResult AddItems()
        {
            IList<Category> ctList = OurDbContext.Category.ToList<Category>();
            ViewBag.vb = ctList;
            return View();
        }
        [HttpPost]
        public IActionResult AddItems(Items it , ICollection<IFormFile> Image)
        {
            string wwwrootPath = env.WebRootPath;
            string PPFolderPath = wwwrootPath + "/images/";

            foreach (var file in Image)
            {
                string Name = file.Name;
                string FileName = file.FileName;
                long FileLength = file.Length;

                string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileName);
                Random r = new Random();

                FileNameWithoutExtension = DateTime.Now.ToString("ddMMyyyyhhmm") + r.Next(1, 1000).ToString();
                string Extention = Path.GetExtension(FileName);

                FileStream fs = new FileStream(PPFolderPath + FileNameWithoutExtension + Extention, FileMode.CreateNew);
                file.CopyTo(fs);
                fs.Close();
                fs.Dispose();

                it.Image = "~/images/" + FileNameWithoutExtension + Extention;

            }

            OurDbContext.Items.Add(it);
            OurDbContext.SaveChanges();
            IList<Category> ctList = new List<Category>();
            ViewBag.vb = ctList;
            return RedirectToAction(nameof(ItemsList));
        }
        public IActionResult ItemsList()
        {
                return View(OurDbContext.Items.ToList<Items>());
        }
        public IActionResult ItemsDetail(int ItemsID)
        {
           Items obj =  OurDbContext.Items.Where(abc => abc.ItemsId == ItemsID).FirstOrDefault();
            return View(obj);
        }
        public IActionResult ItemDelete(Items it)
        {
            OurDbContext.Items.Remove(it);
            OurDbContext.SaveChanges();               
            return RedirectToAction(nameof(ItemsController.ItemsList));
        }
        [HttpGet]
        public IActionResult ItemEdit(int ItemID)
        {
           Items obj = OurDbContext.Items.Where(abc => abc.ItemsId == ItemID).FirstOrDefault();
            ViewData["ItemId"] = new SelectList(OurDbContext.Items, "ItemsId", "Name");
            IList<Items> iList = OurDbContext.Items.ToList<Items>();
            ViewBag.vb = iList;
            IList<Category> ct = OurDbContext.Category.ToList<Category>();
            ViewBag.category = ct;
            return View(obj);
        }
        [HttpPost]
        public IActionResult ItemEdit(Items it)
        {
            OurDbContext.Items.Update(it);
            OurDbContext.SaveChanges();
            IList<Items> iList = OurDbContext.Items.ToList<Items>();
            ViewBag.vb = iList;
            IList<Category> ct = OurDbContext.Category.ToList<Category>();
            ViewBag.category = ct;
            return RedirectToAction(nameof(ItemsController.ItemsList));
        }
    }
}