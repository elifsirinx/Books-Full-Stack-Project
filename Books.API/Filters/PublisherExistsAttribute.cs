using Books.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class PublisherExistsAttribute : TypeFilterAttribute
    {
        public PublisherExistsAttribute():base(typeof(PublisherExistingFilter))
        {

        }

        private class PublisherExistingFilter : IAsyncActionFilter
        {
            private IPublisherService publisherService;

            public PublisherExistingFilter(IPublisherService publisherService)
            {
                this.publisherService = publisherService;
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!context.ActionArguments.ContainsKey("id"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if(!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var publisher = publisherService.GetPublisherById(id);
                if (publisher == null)
                {
                    context.Result = new NotFoundObjectResult(new { Message = $"{id} is not found!" });
                    return;
                }

                await next();
            }
        }
    }
}
