using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FastFoodClassification.Entities.Dtos
{
    public class BaseDto : IDto
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
