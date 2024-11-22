using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.DTOs.Recipes;
using System.Text.Json;
using Newtonsoft.Json;
using api.Services;
using api.Interfaces;

namespace api.Controllers
{
    [ApiController]
    [Route("api/recipes")]
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
                    var recipeResponse = JsonConvert.DeserializeObject<ComplexSearchResponseDto>(result);
                    Console.WriteLine("Deserialized Response:" + (recipeResponse?.Results != null ? "Not null" : "Null"));

                    if (recipeResponse?.Results != null)
                    {
                        return Ok(recipeResponse.Results);
                    }
                    else
                    {
                        return StatusCode(500, "Error: Recipe response is null");
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"Error parsing JSON: {e.Message}");
                }
            }
            return StatusCode(500, "Error fetching recipes");
        }

        [HttpGet("random/{number}")]
        public async Task<IActionResult> GetRandomRecipe(int number)
        {
            var result = await _recipeService.GetRandomRecipeAsync(number);

            if (result != null)
            {
                try
                {
                    Console.WriteLine("JSON Result:" + result);
                    var recipeResponse = JsonConvert.DeserializeObject<RandomSearchResponseDto>(result);
                    Console.WriteLine("Deserialized Response:" + (recipeResponse?.Recipes != null ? "Not null" : "Null"));

                    if (recipeResponse?.Recipes != null)
                    {
                        return Ok(recipeResponse.Recipes);
                    }
                    else
                    {
                        return StatusCode(500, "Error: Recipe response is null");
                    }
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