using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Recipes;


namespace api.DTOs.Recipes
{
    public class RandomSearchResponseDto
    {
        public List<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();
    }
}