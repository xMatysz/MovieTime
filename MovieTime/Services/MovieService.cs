﻿using MovieTime.Model;
using System.Text.Json;

namespace MovieTime.Services
{
    public class MovieService
    {
        private List<Movie> movieList = new();
        private readonly HttpClient client;

        public MovieService()
        {
            client = new HttpClient();
        }

        public async Task<List<Movie>> GetMovies()
        {
            if (movieList.Count > 0)
                return movieList;

            //var url = "https://www.omdbapi.com/?s=harry+potter&apikey=d30656b1";
            //var response = await client.GetAsync(url);
            //
            //if (response.IsSuccessStatusCode)
            //{
            //    movieList = await response.Content.ReadFromJsonAsync<List<Movie>>();
            //}
            var responseFromApi = "{\"Search\":" +
                    "[" +
                    "{\"Title\":\"Harry Potter and the Deathly Hallows: Part 2\",\"Year\":\"2011\",\"imdbID\":\"tt1201607\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMGVmMWNiMDktYjQ0Mi00MWIxLTk0N2UtN2ZlYTdkN2IzNDNlXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter and the Sorcerer's Stone\",\"Year\":\"2001\",\"imdbID\":\"tt0241527\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMzkyZGFlOWQtZjFlMi00N2YwLWE2OWQtYTgxY2NkNmM1NjMwXkEyXkFqcGdeQXVyNjY1NTM1MzA@._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter and the Chamber of Secrets\",\"Year\":\"2002\",\"imdbID\":\"tt0295297\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMjE0YjUzNDUtMjc5OS00MTU3LTgxMmUtODhkOThkMzdjNWI4XkEyXkFqcGdeQXVyMTA3MzQ4MTc0._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter and the Prisoner of Azkaban\",\"Year\":\"2004\",\"imdbID\":\"tt0304141\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTY4NTIwODg0N15BMl5BanBnXkFtZTcwOTc0MjEzMw@@._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter and the Goblet of Fire\",\"Year\":\"2005\",\"imdbID\":\"tt0330373\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTI1NDMyMjExOF5BMl5BanBnXkFtZTcwOTc4MjQzMQ@@._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter and the Order of the Phoenix\",\"Year\":\"2007\",\"imdbID\":\"tt0373889\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTM0NTczMTUzOV5BMl5BanBnXkFtZTYwMzIxNTg3._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter and the Deathly Hallows: Part 1\",\"Year\":\"2010\",\"imdbID\":\"tt0926084\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BMTQ2OTE1Mjk0N15BMl5BanBnXkFtZTcwODE3MDAwNA@@._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter and the Half-Blood Prince\",\"Year\":\"2009\",\"imdbID\":\"tt0417741\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BNzU3NDg4NTAyNV5BMl5BanBnXkFtZTcwOTg2ODg1Mg@@._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter 20th Anniversary: Return to Hogwarts\",\"Year\":\"2022\",\"imdbID\":\"tt16116174\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BNTZkNWEyZTgtYzJlOS00OWNiLTgwZjMtZGU5NTRhNDNjOTRhXkEyXkFqcGdeQXVyNjk1Njg5NTA@._V1_SX300.jpg\"}," +
                    "{\"Title\":\"Harry Potter and the Forbidden Journey\",\"Year\":\"2010\",\"imdbID\":\"tt1756545\",\"Type\":\"movie\",\"Poster\":\"https://m.media-amazon.com/images/M/MV5BNDM0YzMyNGUtMTU1Yy00OTE2LWE5NzYtZDZhMTBmN2RkNjg3XkEyXkFqcGdeQXVyMzU5NjU1MDA@._V1_SX300.jpg\"}" +
                    "]" +
                    ",\"totalResults\":\"127\",\"Response\":\"True\"}";

            movieList = JsonSerializer.Deserialize<List<Movie>>(responseFromApi.Substring(responseFromApi.IndexOf("["), responseFromApi.IndexOf("]") - responseFromApi.IndexOf("[") + 1));

            return movieList;
        }
    }
}