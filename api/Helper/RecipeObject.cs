using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Recipes;

namespace api.Helpers
{
    public class RecipeObject
    {
        public List<RecipeDto> Results { get; set; }
        public int Offset { get; set; }
        public int Number { get; set; }
        public int TotalResults { get; set; }
    }
}