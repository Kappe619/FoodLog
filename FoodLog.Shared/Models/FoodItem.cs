using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLog.Shared.Models
{
    /// <summary>
    /// Represents a food item with nutritional information such as name, calories, and protein content.
    /// </summary>
    public class FoodItem
    {
        /// <summary>
        /// Gets or sets the name of the food item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of calories in the food item.
        /// </summary>
        public int Calories { get; set; }

        /// <summary>
        /// Gets or sets the amount of protein (in grams) in the food item.
        /// </summary>
        public double Protein { get; set; }

        public FoodItem()
        {
            
        }

    }
}
