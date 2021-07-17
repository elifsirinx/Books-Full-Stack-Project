using Books.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Filters
{
    public class GenreExistsAttribute : TypeFilterAttribute
    {
        public GenreExistsAttribute() : base(typeof(GenreExistingFilter))
        {

        }

        private class GenreExistingFilter : IAsyncActionFilter
        {
            private IGenreService genreService;

            public GenreExistingFilter(IGenreService genreService)
            {
                this.genreService = genreService;
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

                var genre = genreService.GetGenreById(id);
                if (genre == null)
                {
                    context.Result = new NotFoundObjectResult(new { Message = $"{id} is not found!" });
                    return;
                }

                await next();
            }
        }
    }
}

