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
    }
}
