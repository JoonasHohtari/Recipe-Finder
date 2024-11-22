using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using api.DTOs.Recipes;
using api.DTOs.Ingredients;
using api.Interfaces;

namespace api.Services
{
    public class RecipeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ILogger<RecipeService> _logger;

        public RecipeService(HttpClient httpClient, ILogger<RecipeService> logger)
        {
            _httpClient = httpClient;
            _apiKey = Environment.GetEnvironmentVariable("SPOONACULAR_API_KEY");
            _logger = logger;
        }


        public async Task<string> GetRecipesAsync(string query, int number)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/complexSearch?apiKey={_apiKey}&query={query}&number={number}");
                if (string.IsNullOrEmpty(response))
                {
                    _logger.LogWarning("Received empty response from Spoonacular API");
                    return null;
                }
                return response;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError($"An error occured while making the HTTP request: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error: {e.Message}");
                return null;
            }

        }

        public async Task<string> GetRandomRecipeAsync(int number)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/random?apiKey={_apiKey}&number={number}");
                if (string.IsNullOrEmpty(response))
                {
                    _logger.LogWarning("Received empty response from Spoonacular API");
                    return null;
                }
                return response;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError($"An error occured while making the HTTP request: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error: {e.Message}");
                return null;

            }
        }

        public async Task<string> GetRecipeByIngridientsAsync(string ingredients, int number)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/findByIngredients?apiKey={_apiKey}&ingredients={ingredients}&number={number}");
                if (string.IsNullOrEmpty(response))
                {
                    return null;
                }
                return response;
            }
            catch
            {
                return null;
            }


        }
    }
}