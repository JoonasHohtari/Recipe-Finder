using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Measurements
{
    public class MeasuresDto
    {
        public MeasuresMetricDto Metric { get; set; }
        public MeasuresImperialDto Us { get; set; }
    }
}