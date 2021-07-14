using Books.Business;
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
        //    //Add value proccess
        //    [HttpPost]
        //    public IActionResult AddPublisher(AddNewPublisherRequest request)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            int publishereId = service.AddPublisher(request);
        //            return CreatedAtAction(nameof(GetById), routeValues: new { id = publishereId }, value: null);
        //        }

        //        return BadRequest(ModelState);
        //    }

        //    //Update value proccess
        //    [HttpPut("{id}")]
        //    [PublisherExists]
        //    public IActionResult UpdatePublisher(int id, EditPublisherRequest request)
        //    {
        //        // Above the proccess done by PublisherExist
        //        //var isExisting = service.GetPublisherById(id);
        //        //if(isExisting == null)
        //        //{
        //        //    return NotFound();
        //        //}
        //        if (ModelState.IsValid)
        //        {
        //            int newItemId = service.UpdatePublisher(request);
        //            return Ok();
        //        }
        //        return BadRequest(ModelState);
        //    }

        //    //Delete value proccess
        //    [HttpDelete("{id}")]
        //    [PublisherExists]
        //    public IActionResult Delete(int Id)
        //    {
        //        service.DeletePublisher(Id);
        //        return Ok();

        //    }
        //}
    }
}
