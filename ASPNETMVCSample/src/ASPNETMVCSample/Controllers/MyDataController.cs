using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETMVCSample.Models;
using ASPNETMVCSample.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETMVCSample.Controllers
{
    public class MyDataController : Controller
    {
        private readonly IBooksService _booksService;
        public MyDataController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowForm()
        {

            return View(new Book());
        }

        public async Task<IActionResult> Books()
        {
            var books = await _booksService.GetBooksAsync();
            return View(books);
        }

        [HttpPost]
        public string ShowForm(Book book)
        {
            return $"{book.Title} {book.Publisher}";
        }
    }
}
