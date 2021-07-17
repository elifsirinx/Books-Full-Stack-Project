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
    
    public class GenresController : ControllerBase
    {
        private IGenreService service;
        public GenresController(IGenreService genreService)
        {
            service = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GetAllGenre();
            return Ok(result.ToList());
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var genreListResponse = service.GetGenreById(id);

            if (genreListResponse != null)
            {
                return Ok(genreListResponse);
            }
            return NotFound();
        }

        [HttpGet("GetGenreByGenreName/{genreName}")]
        public IActionResult GetGenreByGenreName(string genreName)
        {

            var genresdto = service.GetGenreByGenreName(genreName);
            if (genresdto != null)
            {
                return Ok(genresdto);
            }
            return NotFound();

        }
        [HttpGet("GetGenreByBookTitle/{bookTitle}")]
        public IActionResult GetGenreByBookTitle(string bookTitle)
        {
            var genresdto = service.GetGenreByBookTitle(bookTitle);
            if (genresdto != null)
            {
                return Ok(genresdto);
            }
            return NotFound();

        }

        //Add value proccess
        [HttpPost]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult AddGenre(AddNewGenreRequest request)
        {
            if (ModelState.IsValid)
            {
                int genreId = service.AddGenre(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = genreId }, value: null);
            }

            return BadRequest(ModelState);
        }

        //Update value proccess
        [HttpPut("{id}")]
        [GenreExists]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult UpdateGenre(int id, EditGenreRequest request)
        {

            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateGenre(request);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //Delete value proccess
        [HttpDelete("{id}")]
        [GenreExists]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Delete(int Id)
        {
            service.DeleteGenre(Id);
            return Ok();

        }
    }
}

