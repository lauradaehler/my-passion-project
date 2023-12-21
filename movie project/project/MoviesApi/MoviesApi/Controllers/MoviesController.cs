using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Repositories;
using System.Data.SqlClient;
using System.Net;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository repository)
        {
            _movieRepository = repository;
        }

        //Implement controller methods here
        // GET: api/Movies

        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return _movieRepository.GetMovies();
        }

        [HttpPost]
        public bool InsertMovie(Movie movie)
        {
            Console.WriteLine("blah blah test");

            return _movieRepository.InsertMovie(movie);
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> UpdateMovie([FromBody] Movie movie)
        {
            try
            {
                return _movieRepository.UpdateMovie(movie);
            } catch (SqlException ex)
            {
                return BadRequest("SQL error occurred.");
            }
        }

        [HttpGet("{id}/movieExists")]
        public bool MovieExists(int id)
        {
            return GetMovieById(id).ID != -1;
        }

        [HttpDelete("{id}")]
        public bool DeleteMovie(int id)
        {
            Console.WriteLine("delete" + id);
            return _movieRepository.DeleteMovie(id);
        }


    }
}
