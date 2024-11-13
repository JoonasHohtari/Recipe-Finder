using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class RecipeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = Environment.GetEnvironmentVariable("SPOONACULAR_API_KEY");
        }
        public async Task<string> GetRecipesAsync(string query)
        {
            var response = await _httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/complexSearch?apiKey={_apiKey}&query={query}");

            if (response == null)
            {
                return null;
            }


            return response;

        }
    }
}