using Movies.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie();
        Task<Movie> CreateMovie();
        Task<Movie> UpdateMovie();
        Task DeleteMovie();
    }
}
