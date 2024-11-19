using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Ingredients;
using api.DTOs.Measurements;

namespace api.DTOs.Recipes
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? ImageType { get; set; }
        public int? Servings { get; set; }
        public int? ReadyInMinutes { get; set; }
        public double? HealthScore { get; set; }
        public string? Instructions { get; set; }
        public List<IngredientDto>? Ingredients { get; set; } = new List<IngredientDto>();
        public List<MeasuresDto>? Measurements { get; set; } = new List<MeasuresDto>();
        public string? Summary { get; set; }
    }
}