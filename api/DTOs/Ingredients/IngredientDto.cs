using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Ingredients
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Aisle { get; set; }
        public string Image { get; set; }
        public string Consistency { get; set; }
        public string Name { get; set; }
        public string NameClean { get; set; }
        public string Original { get; set; }
        public string OriginalName { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public List<string> Meta { get; set; }
        public MeasuresDto Measures { get; set; }
    }

    public class MeasuresDto
    {
        public MeasureDto Us { get; set; }
        public MeasureDto Metric { get; set; }
    }

    public class MeasureDto
    {
        public double Amount { get; set; }
        public string UnitShort { get; set; }
        public string UnitLong { get; set; }
    }

}