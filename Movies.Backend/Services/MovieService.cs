using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Backend.Data;
using Movies.Backend.Models;
using Movies.Backend.Repositories;

namespace Movies.Backend.Services
{
    public class MovieService: IMovieService
    {
        private readonly MoviesDbContext _moviesDbContext;

        /// <inheritdoc />
        public MovieService(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        /// <inheritdoc />
        public async Task<List<Movie>> GetAllMovies()
        {
            var movies = await _moviesDbContext.Movies.ToListAsync();
            return movies;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Movie> GetMovie([FromRoute] Guid id)
        {
            var movie = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return movie;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public async Task<Movie> AddMovie([FromBody] Movie movie)
        {
            movie.Id = Guid.NewGuid();
            await _moviesDbContext.Movies.AddAsync(movie);
            await _moviesDbContext.SaveChangesAsync();

            return movie;
        }


        public async Task<Movie> UpdateMovie([FromRoute] Guid id, [FromBody] Movie movie)
        {
            var existingMovie = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.MinutesDuration = movie.MinutesDuration;

                await _moviesDbContext.SaveChangesAsync();
                return existingMovie;

            }

            return null;
        }


        public async Task<bool> DeleteMovie([FromRoute] Guid id)
        {
            var existingMovie = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMovie != null)
            {
                _moviesDbContext.Remove(existingMovie);
                await _moviesDbContext.SaveChangesAsync();
                return true;

            }

            return false;


        }




    }
}
