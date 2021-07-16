using Books.API.Filters;
using Books.Business;
using Books.Business.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService service;
        public BooksController(IBookService bookService)
        {
            service = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GetAllBook();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bookListResponse = service.GetBookById(id);
            if (bookListResponse != null)
            {
                return Ok(bookListResponse);
            }
            return NotFound();
        }
        //Add value proccess
        [HttpPost]
        public IActionResult AddPublisher(AddNewBookRequest request)
        {
            if (ModelState.IsValid)
            {
                int publishereId = service.AddBook(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = publishereId }, value: null);
            }

            return BadRequest(ModelState);
        }

        //Update value proccess
        [HttpPut("{id}")]
        [BookExists]
        public IActionResult UpdateBook(int id, EditBookRequest request)
        {
            
            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateBook(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //Delete value proccess
        [HttpDelete("{id}")]
        [BookExists]
        public IActionResult Delete(int Id)
        {
            service.DeleteBook(Id);
            return Ok();

        }
    }
}

