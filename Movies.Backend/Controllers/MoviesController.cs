using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Backend.Data;
using Movies.Backend.Models;
using Movies.Backend.Repositories;

namespace Movies.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            return Ok(movies);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetMovie")]
        public async Task<IActionResult> GetMovie([FromRoute] Guid id)
        {
            var movie = await _movieService.GetMovie(id);
            if (movie != null)
                return Ok(movie);

            return NotFound("Could not fetch a Movie");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            var new_movie = await _movieService.AddMovie(movie);
            
            //201 response*/
            return CreatedAtAction(nameof(GetMovie), new { id = new_movie.Id}, new_movie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:guid}")]
        //first parameter is the object id, second are the changes
        public async Task<ActionResult> UpdateMovie([FromRoute] Guid id, [FromBody] Movie movie)
        {
            return Ok(await _movieService.UpdateMovie(id, movie));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteMovie([FromRoute] Guid id)
        {
            return Ok(await _movieService.DeleteMovie(id));

        }



    }
}
