using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MobileShope.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Slider()
        {
            return View();
        }
    }
}