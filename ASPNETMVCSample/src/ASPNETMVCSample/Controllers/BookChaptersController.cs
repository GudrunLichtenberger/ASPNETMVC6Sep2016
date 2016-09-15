using ASPNETMVCSample.Models;
using ASPNETMVCSample.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETMVCSample.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    public class BookChaptersController : Controller
    {
        private readonly IBookChaptersService _service;
        public BookChaptersController(IBookChaptersService repository)
        {
            _service = repository;
        }

        // GET: api/bookchapters
        [HttpGet()]
        public IEnumerable<BookChapter> GetBookChapters() => _service.GetAll();

        // GET api/bookchapters/guid
        [HttpGet("{id}", Name = nameof(GetBookChapterById))]
        public IActionResult GetBookChapterById(string id)
        {
            BookChapter chapter = _service.Find(id);
            if (chapter == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(chapter);
            }
        }

        // POST api/bookchapters
        [HttpPost]
        public IActionResult PostBookChapter([FromBody]BookChapter chapter)
        {
            if (chapter == null)
            {
                return BadRequest();
            }
            _service.Add(chapter);
            // return a 201 response, Created
            return CreatedAtRoute(nameof(GetBookChapterById), new { id = chapter.Id }, chapter);
        }

        // PUT api/bookchapters/guid
        [HttpPut("{id}")]
        public IActionResult PutBookChapter(string id, [FromBody]BookChapter chapter)
        {
            if (chapter == null || id != chapter.Id)
            {
                return BadRequest();
            }
            if (_service.Find(id) == null)
            {
                return NotFound();
            }

            _service.Update(chapter);
            return new NoContentResult();  // 204
        }

        // DELETE api/bookchapters/guid
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _service.Remove(id);
            // void returns 204, No Content
        }
    }
}
