using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Recipes;

namespace api.DTOs.Recipes
{
    public class ComplexSearchResponseDto
    {
        public List<RecipeDto> Results { get; set; } = new List<RecipeDto>();
        public int? Offset { get; set; }
        public int? Number { get; set; }
        public int? TotalResults { get; set; }
    }
}