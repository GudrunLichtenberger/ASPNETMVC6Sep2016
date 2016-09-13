using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETMVCSample.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            return "HomeController - Index";
        }

        public int Add(int x, int y) => x + y + 77;

        public IActionResult Demo()
        {
            var person = new
            {
                FirstName = "Stephanie",
                LastName = "Nagel"
            };
            return Json(person);
        }
    }
}
