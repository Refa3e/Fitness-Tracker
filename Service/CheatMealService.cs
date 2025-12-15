using FitnessTrackerApp.Exceptions;
using FitnessTrackerApp.Model;
using System;
using System.Collections.Generic;

namespace FitnessTrackerApp.Service
{
    public class CheatMealService
    {
        private readonly WeightEntryService weightService = new WeightEntryService();

        private List<CheatMealEntry> GetAllMeals()
        {
            return DataStorage.LoadData<CheatMealEntry>();
        }

        public List<CheatMealEntry> GetMealsAscending(string username)
        {
            List<CheatMealEntry> allMeals = GetAllMeals();
            List<CheatMealEntry> meals = new List<CheatMealEntry>();

            foreach (CheatMealEntry meal in allMeals)
            {
                if (string.Equals(meal.UserName, username, System.StringComparison.OrdinalIgnoreCase))
                {
                    meals.Add(meal);
                }
            }

            meals.Sort((a, b) => a.Date.CompareTo(b.Date));
            return meals;
        }

        public List<CheatMealEntry> GetMealsDescending(string username)
        {
            List<CheatMealEntry> ascending = GetMealsAscending(username);
            ascending.Reverse();
            return ascending;
        }

        public CheatMealEntry GetLatestMeal(string username)
        {
            List<CheatMealEntry> meals = GetMealsDescending(username);

            if (meals.Count == 0)
            {
                return new CheatMealEntry();
            }

            return meals[0];
        }

        public CheatMealEntry GetMealByGuid(string guid)
        {
            List<CheatMealEntry> allMeals = GetAllMeals();

            foreach (CheatMealEntry meal in allMeals)
            {
                if (meal.GUID == guid)
                {
                    return meal;
                }
            }

            return null;
        }

        public void AddNewMeal(CheatMealEntry newMeal, WeightEntry newWeight)
        {
            WeightEntry savedWeight = weightService.AddNewEntry(newWeight);

            newMeal.WeightEntryGUID = savedWeight.GUID;
            newMeal.GUID = Guid.NewGuid().ToString();

            List<CheatMealEntry> allMeals = GetAllMeals();
            allMeals.Add(newMeal);
            DataStorage.SaveData(allMeals);
        }

        public void UpdateMeal(CheatMealEntry updatedMeal, WeightEntry updatedWeight)
        {
            List<CheatMealEntry> allMeals = GetAllMeals();
            CheatMealEntry meal = GetMealByGuid(updatedMeal.GUID);

            if (meal == null)
            {
                throw new RecordNotFoundExeption(updatedMeal.GUID);
            }

            meal.MealName = updatedMeal.MealName;
            meal.Calories = updatedMeal.Calories;
            meal.Date = updatedMeal.Date;

            weightService.UpdateEntry(updatedWeight, meal.WeightEntryGUID);

            DataStorage.SaveData(allMeals);
        }

        public void DeleteMeal(string guid)
        {
            List<CheatMealEntry> allMeals = GetAllMeals();
            CheatMealEntry meal = GetMealByGuid(guid);

            if (meal == null)
            {
                throw new RecordNotFoundExeption(guid);
            }

            weightService.DeleteEntry(meal.WeightEntryGUID);

            allMeals.Remove(meal);
            DataStorage.SaveData(allMeals);
        }

        public bool IsWeightUsedInMeal(string weightGuid)
        {
            List<CheatMealEntry> allMeals = GetAllMeals();

            foreach (CheatMealEntry meal in allMeals)
            {
                if (meal.WeightEntryGUID == weightGuid)
                {
                    return true;
                }
            }

            return false;
        }
    }
}