using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Recipes
{
    public class RandomSearchResponseDto
    {
        public List<RecipeDto> Results { get; set; }
    }
}