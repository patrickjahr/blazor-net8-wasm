using Pazor.Client.Models;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace Pazor.Client.Services
{
    public class TmdbService
    {
        public static string ImageBaseUrl = "https://image.tmdb.org/t/p/w300/";
        public static string NowPlaying = "now_playing";
        public static string Popular = "popular";
        public static string Upcoming = "upcoming";
        public static string TopRated = "top_rated";

        private readonly HttpClient _httpClient;

        public TmdbService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Movie>> GetMovies(string topic)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwYjlmNjlhM2RiNDMzYzZiYzIxMzhkMTA1NTI5YTMwOCIsInN1YiI6IjVlOGIwMGRmZDM2M2U1MDAxN2I4MzVmNyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.cXuzthBo4Kc0M75Bc7cJGXeiBc8ajonT6cCFb4BI0-c");
            var root = await _httpClient.GetFromJsonAsync<Root>($"https://api.themoviedb.org/3/movie/{topic}?language=de-DE");

            if (root == null)
            {
                return Enumerable.Empty<Movie>();
            }

            return root.Results;
        }
    }
}
