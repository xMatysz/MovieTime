using System.Net.Http.Json;

namespace MovieTime.Services
{
    public class MovieService
    {
        HttpClient _httpClient;
        public MovieService()
        {
            _httpClient = new HttpClient();
        }
        List<Movie> _moviesList = new();
        public async Task<List<Movie>> GetMovies()
        {
            if(_moviesList?.Count > 0)
                return _moviesList;

            var url = "https://montemagno.com/mokeys.json";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                _moviesList = await response.Content.ReadFromJsonAsync<List<Movie>>();
            }

            return _moviesList;
        }
    }
}