using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<UserInfoViewModel> GetUserInfo()
        {
            var idpClient = _httpClientFactory.CreateClient("IDPClient");

            var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();

            if (metaDataResponse.IsError)
                throw new HttpRequestException("Something went wrong while requesting the access token");

            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var userInfoResponse = await idpClient.GetUserInfoAsync(new UserInfoRequest
            {
                Address = metaDataResponse.UserInfoEndpoint,
                Token = accessToken
            });

            if (userInfoResponse.IsError)
                throw new HttpRequestException("Something went wrong while getting user info");

            var userInfoDictionary = new Dictionary<string, string>();

            foreach(var claim in userInfoResponse.Claims)
            {
                userInfoDictionary.Add(claim.Type, claim.Value);
            }

            return new UserInfoViewModel(userInfoDictionary);
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var httpClient = _httpClientFactory.CreateClient("MovieAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "/movies");

            var response = await httpClient
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Movie>>(content);
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
