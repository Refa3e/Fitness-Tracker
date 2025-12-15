using System;

namespace FitnessTrackerApp.Model
{
    /// <summary>
    /// Represents a food item with nutritional information.
    /// Stores food name, calories, and protein content.
    /// </summary>
    public class FoodEntry
    {
        /// <summary>
        /// Gets or sets the unique identifier for this food entry.
        /// </summary>
        public string GUID { get; set; }

        /// <summary>
        /// Gets or sets the name of the food item.
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// Gets or sets the number of calories in the food item.
        /// </summary>
        public decimal Calories { get; set; }

        /// <summary>
        /// Gets or sets the protein content in grams.
        /// </summary>
        public decimal Protein { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who created this food entry.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the date when this food entry was created/added.
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}