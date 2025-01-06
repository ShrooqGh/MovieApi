using MovieApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Features;
using MovieApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using Azure.Messaging;
using System.Data;
using System.Threading.Tasks;


namespace MovieApi.MovieRepository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _movieContext;

        public MovieRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public void InsertMovie(Movie movie) 
        {
           _movieContext.Movies.Add(movie);
           _movieContext.SaveChangesAsync();
        }

        public  async Task CreateProductAsync()
        {
            // Check if products already exist, this ensures we don't insert duplicates
            if (_movieContext.Movies.Any())
                return;
            // Define two new products
            var movie1 = new Movie
            {
                Id = 1,
                Title = "Heaven has eyes",
                Type = "Horror",
                Description = "New movie in cinema",
                ReleasedDay = new DateTime(2010,06,07)

            };
            var movie2 = new Movie
            {
                Id = 2,
                Title = "Home alone",
                Type = "Drama",
                Description = "New year movie",
                ReleasedDay = new DateTime(2009,01,01)

            };

            // Add products asynchronously to the DbSet
            await _movieContext.Movies.AddAsync(movie1);
            await _movieContext.Movies.AddAsync(movie2);
            // Save the changes asynchronously to the database
            await _movieContext.SaveChangesAsync();
        }
        
        public List<Movie> FetchAllMovies() 
        {
            return _movieContext.Movies.ToList();
        }

        public  Movie FetchMovieById(int id) 
        {
            var movie = _movieContext.Movies.FirstOrDefault(x => x.Id == id);
            return movie;
           
        }

        public void UpdateMovieType(int id, string type) 
        {
            var movieToUpdate = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movieToUpdate != null) 
            {
                movieToUpdate.Type = type;
                _movieContext.SaveChangesAsync();

            }
        }

        public void UpdateMovieDescription(int id, string description)
        {
            var movieToUpdate = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movieToUpdate != null)
            {
                movieToUpdate.Description = description;
                _movieContext.SaveChangesAsync();
            }
            
        }

        public void UpdateMovieReleaseDay(int id, DateTime releaseDay)
        {
            var movieToUpdate = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movieToUpdate != null)
            {
                movieToUpdate.ReleasedDay = releaseDay;
                _movieContext.SaveChangesAsync();
            }
        }

        public void DeleteMovie(int id)
        {
            var ToDelete = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
            if(ToDelete != null)
            {
                _movieContext.Movies.Remove(ToDelete);
                _movieContext.SaveChangesAsync();
            }
        }

    }
}
