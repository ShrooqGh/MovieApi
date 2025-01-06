using MovieApi.Models;

namespace MovieApi.Repository
{
    public interface IMovieRepository
    {
        public void InsertMovie(Movie movie);

        public List<Movie> FetchAllMovies();

        public Movie FetchMovieById(int id);
                
        public void UpdateMovieType(int id, string type);

        public void UpdateMovieDescription(int id, string description);

        public void UpdateMovieReleaseDay(int id, DateTime releaseDay);

        public void DeleteMovie(int id);
    }
}
