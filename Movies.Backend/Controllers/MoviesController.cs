using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Backend.Data;
using Movies.Backend.Models;

namespace Movies.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MoviesDbContext moviesDbContext;

        public MoviesController(MoviesDbContext moviesDbContext)
        {
            this.moviesDbContext = moviesDbContext;
        }

        //Get All Movies
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await moviesDbContext.Movies.ToListAsync();
            return Ok(movies);
        }

        //get single Movie
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetMovie")]
        public async Task<IActionResult> GetMovie([FromRoute] Guid id)
        {
            var movie = await moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie != null)
                return Ok(movie);
            return NotFound("Could not fetch a Movie");
        }

        //add Movie
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            movie.Id = Guid.NewGuid();
            await moviesDbContext.Movies.AddAsync(movie);
            await moviesDbContext.SaveChangesAsync();

            //201 response
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id}, movie);
        }

        //Updating a movie
        [HttpPut]
        [Route("{id:guid}")]
        //first parameter is the object id, second are the changes
        public async Task<ActionResult> UpdateMovie([FromRoute] Guid id, [FromBody] Movie movie)
        {
            var existingMovie = await moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id) ;

            if(existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.MinutesDuration = movie.MinutesDuration;


                await moviesDbContext.SaveChangesAsync();
                return Ok(existingMovie);

            }

            return NotFound("Could not update the Movie");


        }

        //Deleting a movie
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> UpdateMovie([FromRoute] Guid id)
        {
            var existingMovie = await moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMovie != null)
            {
                moviesDbContext.Remove(existingMovie);
                await moviesDbContext.SaveChangesAsync();  
                return Ok(existingMovie);

            }

            return NotFound("Could not delete the Movie");


        }



    }
}
