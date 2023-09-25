using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodClassification.Entities.Dtos
{
    public class FastFoodResponseDto
    {
        public string? Label { get; set; }
        public string? Predicted { get; set; } 
        public string? Name { get; set; }
        public float[]? Accuracy { get; set; }
        public float? PredictRate { get; set; }
    }
}
