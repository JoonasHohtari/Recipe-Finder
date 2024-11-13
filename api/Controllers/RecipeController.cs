using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.DTOs.Recipes;
using api.Helpers;
using System.Text.Json;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("{query}/{number}")]
        public async Task<IActionResult> GetRecipes(string query, int number)
        {
            var result = await _recipeService.GetRecipesAsync(query, number);

            if (result != null)
            {
                try
                {
                    Console.WriteLine("JSON Result:" + result);
                    var recipeResponse = JsonConvert.DeserializeObject<RecipeObject>(result);
                    
                    // Log the deserialized object
                    Console.WriteLine("Deserialized Results: " + (recipeResponse?.Results != null ? "Not Null" : "Null"));
                    Console.WriteLine("Offset: " + recipeResponse?.Offset);
                    Console.WriteLine("Number: " + recipeResponse?.Number);
                    Console.WriteLine("TotalResults: " + recipeResponse?.TotalResults);
                    return Ok(recipeResponse);
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"Error parsing JSON: {e.Message}");
                }
            }
            return StatusCode(500, "Error fetching recipes");
        }
        [HttpGet("random{number}")]
        public async Task<IActionResult> GetRandomRecipes(int number)
        {
            var result = await _recipeService.GetRandomRecipesAsync(number);

            if (result != null)
            {
                try
                {
                    Console.WriteLine("JSON Result:" + result);
                    var recipeResponse = JsonConvert.DeserializeObject<RecipeObject>(result);
                    
                    // Log the deserialized object
                    Console.WriteLine("Deserialized Results: " + (recipeResponse?.Results != null ? "Not Null" : "Null"));
                    Console.WriteLine("Offset: " + recipeResponse?.Offset);
                    Console.WriteLine("Number: " + recipeResponse?.Number);
                    Console.WriteLine("TotalResults: " + recipeResponse?.TotalResults);
                    return Ok(recipeResponse);
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"Error parsing JSON: {e.Message}");
                }
            }
            return StatusCode(500, "Error fetching recipes");
        }
    }
}