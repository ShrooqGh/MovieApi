using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.MovieServices;

namespace MovieApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieServices _movieServices;

        public MoviesController(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            try
            {
                return  Ok(_movieServices.RetriveAllMovies());
            }
            catch (Exception ex)
            {
                return NotFound("Movie not found");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            try
            {
                return Ok(_movieServices.RetriveSpecificMovie(id));
            }
            catch (Exception ex)
            {
                
                return NotFound("Movie not found");
            }
        }

        [HttpPost]
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        public async Task<ActionResult<string>> CreateMovie(Movie movie)
        {
            try
            {
                _movieServices.AddMovie(movie);
                return StatusCode(201, "Movie Placed");
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult<string>> ModifyDescription(int id, string description)
        {
            try
            {
                _movieServices.ModifyMovieDescription(id, description);
                return Ok("Description Modified");
            }
            catch (Exception ex)
            {
        
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{type}")]
        public async Task<ActionResult<string>> ModifyType(int id, string type)
        {
            try
            {
                _movieServices.ModifyMovieType(id, type);
                return Ok("Type for the Movie has been Modified");
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<string>> ModifyReleaseDay(int id, DateTime releaseDay)
        {
            try
            {
                _movieServices.ModifyMovieReleaseDay(id, releaseDay);
                return Ok("Release Day for the Movie has been Modified");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Movie>> CancelMovie(int id)
        {
            try
            {
                _movieServices.RemoveMovie(id); 
                return Ok("Movie has been Delleted");
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
    }
}
