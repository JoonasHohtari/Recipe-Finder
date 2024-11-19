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
        public async Task<IActionResult> GetRecipes([FromQuery] string query, [FromQuery] int number)
        {
            var result = await _recipeService.GetRecipesAsync(query, number);

            if (result != null)
            {
                try
                {
                    var recipeResponse = JsonConvert.DeserializeObject<ComplexSearchResponseDto>(result);

                    return Ok(recipeResponse);
                }
                catch (Exception e)
                {
                    return StatusCode(500, $"Error parsing JSON: {e.Message}");
                }
            }
            return StatusCode(500, "Error fetching recipes");
        }

        [HttpGet("random/{number}")]
        public async Task<IActionResult> GetRandomRecipe([FromQuery] int number)
        {
            var result = await _recipeService.GetRandomRecipeAsync(number);

            if (result != null)
            {
                try
                {
                    var recipeResponse = JsonConvert.DeserializeObject<RandomSearchResponseDto>(result);
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