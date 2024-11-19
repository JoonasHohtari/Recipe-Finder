using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using api.DTOs.Recipes;
using api.DTOs.Measurements;
using api.DTOs.Ingredients;
using api.Interfaces;

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

        
        public async Task<ComplexSearchResponseDto> GetRecipesAsync(string query, int number)
        {
            var response = await _httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/complexSearch?apiKey={_apiKey}&query={query}&number={number}");
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ComplexSearchResponseDto>(response);
        }

        public async Task<RandomSearchResponseDto> GetRandomRecipeAsync(int number)
        {
            var response = await _httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/random?apiKey={_apiKey}&number={number}");
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<RandomSearchResponseDto>(response);
        }

        public async Task<string> GetRecipeByIngridientsAsync(string ingredients, int number)
        {
            var response = await _httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/findByIngredients?apiKey={_apiKey}&ingredients={ingredients}&number={number}");
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            return response;        
        
        }
    }
}