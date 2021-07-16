using Books.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class BookExistsAttribute : TypeFilterAttribute
    {
        public BookExistsAttribute() : base(typeof(BookExistingFilter))
        {

        }

        private class BookExistingFilter : IAsyncActionFilter
        {
            private IBookService bookService;

            public BookExistingFilter(IBookService bookService)
            {
                this.bookService = bookService;
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!context.ActionArguments.ContainsKey("id"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if (!(context.ActionArguments["id"] is int id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var book = bookService.GetBookById(id);
                if (book == null)
                {
                    context.Result = new NotFoundObjectResult(new { Message = $"{id} is not found!" });
                    return;
                }

                await next();
            }
        }
    }
}

