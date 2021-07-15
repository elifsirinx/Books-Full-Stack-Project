using Books.API.Filters;
using Books.Business;
using Books.Business.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class PublishersController : ControllerBase
    {
        private IPublisherService service;
        public PublishersController(IPublisherService publisherService)
        {
            service = publisherService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var result = service.GetAllPublisher();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var publisherListResponse = service.GetPublisherById(id);
            if(publisherListResponse != null)
            {
                return Ok(publisherListResponse);
            }
            return NotFound();
        }
        //Add value proccess
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

        //Update value proccess
        [HttpPut("{id}")]
        [PublisherExists]
        public IActionResult UpdatePublisher(int id, EditPublisherRequest request)
        {
            // Above the proccess done by PublisherExist
            //var isExisting = service.GetPublisherById(id);
            //if(isExisting == null)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                int newItemId = service.UpdatePublisher(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //Delete value proccess
        [HttpDelete("{id}")]
        [PublisherExists]
        public IActionResult Delete(int Id)
        {
            service.DeletePublisher(Id);
            return Ok();
           
        }
    }
}
