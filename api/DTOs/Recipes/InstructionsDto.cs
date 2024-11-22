using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Recipes
{
    public class InstructionsDto
    {
        public string Name { get; set; }
        public List<StepDto> Steps { get; set; }
    }

    public class StepDto
    {
        public int Number { get; set; }
        public string StepDescription { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
        public List<EquipmentDto> Equipment { get; set; }
        public LengthDto Length { get; set; }
    }

    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string Image { get; set; }
    }

    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string Image { get; set; }
    }

    public class LengthDto
    {
        public int Number { get; set; }
        public string Unit { get; set; }
    }
}