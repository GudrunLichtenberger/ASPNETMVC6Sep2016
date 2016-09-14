using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETMVCSample.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETMVCSample.Controllers
{
    public class ViewsDemoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.SomeData = "from the controller";

            ViewData["SomeData1"] = "more data from the controller";

            return View("AnotherView");
        }

        public IActionResult StronglyTyped()
        {
            var b = new Book { BookId = 1, Title = "Professional C# 6", Publisher = "Wrox Press" };
            return View(b);
        }

        public IActionResult UseMyPartialView()
        {
            return View();
        }

        public IActionResult UseMyPartialView2()
        {
            return View();
        }


        public IActionResult MyPartialView()
        {
            return PartialView();
        }
    }
}
