using Movies.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var moviesList = new List<Movie>();

            moviesList.Add(new Movie
            {
                Id = 1,
                Genre = "Comics",
                Title = "asd",
                Rating = "9.2",
                ImageUrl = "images/src",
                ReleaseDate = DateTime.Now,
                Owner = "swn"
            });

            return await Task.FromResult(moviesList);
        }

        public Task<Movie> GetMovie()
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> CreateMovie()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMovie()
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> UpdateMovie()
        {
            throw new System.NotImplementedException();
        }
    }
}
