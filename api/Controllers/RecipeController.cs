using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Services;

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
        [HttpGet("{query}")]
        public async Task<ActionResult> GetRecipes([FromQuery] string query)
        {
            var result = await _recipeService.GetRecipesAsync(query);
            return result != null
                ? Ok(result)
                : StatusCode(500, "An error occurred while fetching recipes.");
        }
    }
}