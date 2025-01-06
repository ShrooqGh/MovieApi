using MovieApi.Models;
using MovieApi.Repository;

namespace MovieApi.MovieServices
{
    public class MovieServices : IMovieServices
    { 
        private readonly IMovieRepository _movieRepository;

        public MovieServices(IMovieRepository repository) 
        {
            _movieRepository = repository;
        }

        public IMovieRepository GetMovieRepository() 
        {
            return _movieRepository;
        }

        public void AddMovie(Movie movie)
        {
            try
            {
                var existingMovie = _movieRepository.FetchMovieById(movie.Id);
                if (existingMovie != null)
                {
                    throw new Exception("Movie already Exist!!");
                }
                _movieRepository.InsertMovie(movie);
            }
            catch
            {
                throw;
            }
        }

        public void RemoveMovie(int id)
        {
            try
            {
                var existingMovie = _movieRepository.FetchMovieById(id);
                if (existingMovie == null)
                {
                    throw new Exception("Movie Not Found!!");
                }
                _movieRepository.DeleteMovie(id);
            }
            catch
            {
                throw;
            }
        }

        public void ModifyMovieType(int id, string type)
        {
            try
            {
                var existingItem = _movieRepository.FetchMovieById(id);
                if (existingItem == null)
                {
                    throw new Exception("Movie not found!!");
                }
                _movieRepository.UpdateMovieType(id, type);
            }
            catch
            {
                throw;
            }
        }

        public void ModifyMovieDescription(int id, string description)
        {
            try
            {
                var existingItem = _movieRepository.FetchMovieById(id);
                if (existingItem == null)
                {
                    throw new Exception("Movie not found!!");
                }
                _movieRepository.UpdateMovieDescription(id, description);
            }
            catch
            {
                throw;
            }
        }

        public void ModifyMovieReleaseDay(int id, DateTime releaseDay)
        {
            try
            {
                var existingItem = _movieRepository.FetchMovieById(id);
                if (existingItem == null)
                {
                    throw new Exception("Movie not found!!");
                }
                _movieRepository.UpdateMovieReleaseDay(id, releaseDay);
            }
            catch
            {
                throw;
            }
        }

        public List<Movie> RetriveAllMovies()
        {
            try
            {
                return _movieRepository.FetchAllMovies();
            }
            catch
            {
                throw;
            }
        }

        public Movie RetriveSpecificMovie(int id)
        {
            try
            {
                return _movieRepository.FetchMovieById(id);
            }
            catch
            {
                throw;
            }
        }

    }
}
