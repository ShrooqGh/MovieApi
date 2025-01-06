using MovieApi.Models;
using MovieApi.MovieRepository;

namespace MovieApi.MovieServices
{
    public interface IMovieServices
    {
        public void AddMovie(Movie movie);

        public void RemoveMovie(int id);

        public void ModifyMovieType(int id, string type);

        public void ModifyMovieDescription(int id, string description);

        public void ModifyMovieReleaseDay(int id, DateTime releaseDay);
        public List<Movie> RetriveAllMovies();

        public Movie RetriveSpecificMovie(int id);
    }
}
