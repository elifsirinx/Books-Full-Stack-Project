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
    public class PublisherController : ControllerBase
    {
        private IPublisherService service;
        public PublisherController(IPublisherService publisherService)
        {
            service = publisherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GetAllPublisher();
            return Ok(result);
        }
    }
}
