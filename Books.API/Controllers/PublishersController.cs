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
    public class PublishersController : ControllerBase
    {
        private IPublisherService service;
        public PublishersController(IPublisherService publisherService)
        {
            service = publisherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GetAllPublisher();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisherListResponse = service.GetPublisherById(id);
            if(publisherListResponse != null)
            {
                return Ok(publisherListResponse);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddPublisher(AddNewPublisherRequest request)
        {
            if (ModelState.IsValid) 
            {
                int publishereId = service.AddPublisher(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = publishereId }, value: null);
            }

            return BadRequest(ModelState);
            

        }
    }
}
