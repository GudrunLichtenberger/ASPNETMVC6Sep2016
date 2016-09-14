using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETMVCSample.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETMVCSample.Controllers
{
    public class MyDataController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowForm()
        {

            return View(new Book());
        }

        [HttpPost]
        public string ShowForm(Book book)
        {
            return $"{book.Title} {book.Publisher}";
        }
    }
}
