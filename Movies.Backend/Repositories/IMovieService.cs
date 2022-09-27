using Microsoft.AspNetCore.Mvc;
using Movies.Backend.Models;

namespace Movies.Backend.Repositories
{
    public interface IMovieService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Movie>> GetAllMovies();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Movie> GetMovie([FromRoute] Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<Movie> AddMovie([FromBody] Movie movie);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<Movie> UpdateMovie([FromRoute] Guid id, [FromBody] Movie movie);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteMovie([FromRoute] Guid id);

    }
}
