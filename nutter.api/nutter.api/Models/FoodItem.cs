using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nutter.api.Models
{
    public class FoodItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fat { get; set; }
        public decimal Calories { get; set; }
    }
}
