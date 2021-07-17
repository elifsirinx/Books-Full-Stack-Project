using Books.API.Filters;
using Books.Business;
using Books.Business.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
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
        private ILogger<PublishersController> _logger;
        public PublishersController(IPublisherService publisherService, ILogger<PublishersController> logger)
        {
            service = publisherService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration =300)]
        public IActionResult Get()
        {
            _logger.LogInformation("Get is starting...");
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = service.GetAllPublisher();
            stopwatch.Stop();
            _logger.LogDebug($"fetch data from database , {stopwatch.ElapsedMilliseconds} ms.");

            return Ok(new
            {
                publishers = result,
                value = DateTime.Now.ToString()
            }); 
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ResponseCache(Duration =300, VaryByQueryKeys = new[] { "id" })]
        public IActionResult GetById(int id)
        {
            var publisherListResponse = service.GetPublisherById(id);
            if(publisherListResponse != null)
            {
                return Ok(publisherListResponse);
            }
            return NotFound();
        }

        [HttpGet("GetPublisherByBookTitle/{bookTitle}")]
        [AllowAnonymous]
        public IActionResult GetPublisherByBookTitle(string bookTitle)
        {
            var publishersdto = service.GetPublisherByBookTitle(bookTitle);
            if (publishersdto != null)
            {
                return Ok(publishersdto);
            }
            return NotFound();

        }
        [HttpGet("GetPublisherByPublisherName/{publisherName}")]
        [AllowAnonymous]
        public IActionResult GetPublisherByPublisherName(string publisherName)
        {

            var publishersdto = service.GetPublisherByPublisherName(publisherName);
            if (publishersdto != null)
            {
                return Ok(publishersdto);
                // return Ok(bookListResponse);
            }
            return NotFound();

        }

        //Add value proccess
        [HttpPost]
        [Authorize(Roles = "Admin,Editor")]
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
        [Authorize(Roles = "Admin,Editor")]
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
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Delete(int Id)
        {
            service.DeletePublisher(Id);
            return Ok();
           
        }
    }
}
