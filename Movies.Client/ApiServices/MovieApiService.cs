using IdentityModel.Client;
using Movies.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/movies");

            var response = await httpClient
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Movie>>(content);

            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5005/connect/token",
            //    ClientId = "movieClient",
            //    ClientSecret = "secret",
            //    Scope = "movieAPI"
            //};

            //using var client = new HttpClient();

            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5005");

            //if(disco.IsError)
            //{
            //    return null;
            //}

            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);

            //if(tokenResponse.IsError)
            //{
            //    return null;
            //}

            //using var apiClient = new HttpClient();

            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            //var response = await apiClient.GetAsync("https://localhost:5001/api/movies");
            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();

            //return JsonConvert.DeserializeObject<List<Movie>>(content);
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
