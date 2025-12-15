using System;
using System.Collections.Generic;
using System.Linq;
using FitnessTrackerApp.Exceptions;
using FitnessTrackerApp.Model;

namespace FitnessTrackerApp.Service
{
    /// <summary>
    /// Manages food entry operations.
    /// Provides CRUD operations for food items with their nutritional data.
    /// </summary>
    public class FoodService
    {
        public static FoodService Instance { get; } = new FoodService();

        private FoodService() { }

        /// <summary>
        /// Gets all food entries for a specific user in descending order by date.
        /// </summary>
        public List<FoodEntry> GetDescending(string userName)
        {
            return GetAll()
                .Where(food => food.UserName.Equals(userName))
                .OrderByDescending(food => food.DateCreated)
                .ToList();
        }

        /// <summary>
        /// Gets all food entries for a specific user in ascending order by date.
        /// </summary>
        public List<FoodEntry> GetAscending(string userName)
        {
            return GetAll()
                .Where(food => food.UserName.Equals(userName))
                .OrderBy(food => food.DateCreated)
                .ToList();
        }

        /// <summary>
        /// Gets a food entry by its ID.
        /// </summary>
        public FoodEntry GetById(string id)
        {
            return GetAll().FirstOrDefault(food => food.GUID.Equals(id));
        }

        /// <summary>
        /// Gets a food entry by its ID from a provided list.
        /// </summary>
        public FoodEntry GetById(List<FoodEntry> foods, string id)
        {
            return foods.FirstOrDefault(food => food.GUID.Equals(id));
        }

        /// <summary>
        /// Adds a new food entry.
        /// </summary>
        public FoodEntry Add(FoodEntry food)
        {
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food));
            }

            List<FoodEntry> foods = GetAll();
            food.GUID = Guid.NewGuid().ToString();
            food.DateCreated = DateTime.Now;
            foods.Add(food);
            DataStorage.SaveData(foods);

            return food;
        }

        /// <summary>
        /// Updates an existing food entry.
        /// </summary>
        public void Update(FoodEntry food)
        {
            if (food == null)
            {
                throw new ArgumentNullException(nameof(food));
            }

            List<FoodEntry> foods = GetAll();
            FoodEntry existing = GetById(foods, food.GUID);

            if (existing != null)
            {
                existing.FoodName = food.FoodName;
                existing.Calories = food.Calories;
                existing.Protein = food.Protein;
                DataStorage.SaveData(foods);
            }
            else
            {
                throw new RecordNotFoundException(food.GUID);
            }
        }

        /// <summary>
        /// Deletes a food entry by its ID.
        /// </summary>
        public void Delete(string id)
        {
            List<FoodEntry> foods = GetAll();
            FoodEntry food = GetById(foods, id);

            if (food != null)
            {
                foods.Remove(food);
                DataStorage.SaveData(foods);
            }
            else
            {
                throw new RecordNotFoundException(id);
            }
        }

        /// <summary>
        /// Searches for food entries by name (case-insensitive).
        /// </summary>
        public List<FoodEntry> SearchByName(string userName, string searchTerm)
        {
            return GetDescending(userName)
                .Where(food => food.FoodName.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
        }

        /// <summary>
        /// Gets the total calories for all foods of a specific user.
        /// </summary>
        public decimal GetTotalCalories(string userName)
        {
            return GetAll()
                .Where(food => food.UserName.Equals(userName))
                .Sum(food => food.Calories);
        }

        /// <summary>
        /// Gets the total protein for all foods of a specific user.
        /// </summary>
        public decimal GetTotalProtein(string userName)
        {
            return GetAll()
                .Where(food => food.UserName.Equals(userName))
                .Sum(food => food.Protein);
        }

        /// <summary>
        /// Gets the most frequently used foods by a user (top N).
        /// </summary>
        public List<FoodEntry> GetMostUsed(string userName, int topCount = 5)
        {
            return GetAll()
                .Where(food => food.UserName.Equals(userName))
                .GroupBy(food => food.FoodName)
                .OrderByDescending(g => g.Count())
                .Take(topCount)
                .Select(g => g.First())
                .ToList();
        }

        /// <summary>
        /// Gets all food entries.
        /// </summary>
        public static List<FoodEntry> GetAll()
        {
            return DataStorage.LoadData<FoodEntry>();
        }
    }
}