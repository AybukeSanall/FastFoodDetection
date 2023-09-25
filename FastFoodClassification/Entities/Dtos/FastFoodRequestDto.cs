using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodClassification.Entities.Dtos
{
    public class FastFoodRequestDto
    {
        public SourceType Type { get; set; }
        public string? Data { get; set; }
    }
}
