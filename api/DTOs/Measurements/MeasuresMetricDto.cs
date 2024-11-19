using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Measurements
{
    public class MeasuresMetricDto
    {
        public double? Amount { get; set; }
        public string? UnitLong { get; set; }
        public string? UnitShort { get; set; }
    }
}