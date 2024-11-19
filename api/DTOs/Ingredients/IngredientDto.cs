using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Measurements;

namespace api.DTOs.Ingredients
{
    public class IngredientDto
    {
        public string Aisle { get; set; }
        public double Amount { get; set; }
        public string Consistency { get; set; }
        public int Id { get; set; }
        public string? Image { get; set; }
        public MeasuresDto Measures { get; set; } = new MeasuresDto();
        public List<string>? Meta { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
        public string OriginalName { get; set; }
        public string Unit { get; set; }
    }
}