using FitnessTrackerApp.Exceptions;
using FitnessTrackerApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerApp.Service
{
    public class CheatMealService
    {
        private static CheatMealService instance;

        private static readonly object lockObject = new object();

        public static CheatMealService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new CheatMealService();
                        }
                    }
                }
                return instance;
            }
        }

        public List<CheatMealEntry> GetCheatMeals()
        {
            return DataStorage.LoadData<CheatMealEntry>();
        }

        public bool CheckIfWeightEntryExistsInCheatMeal(string GUID)
        {
            CheatMealEntry cheatMealEntry = GetCheatMeals().FirstOrDefault(obj => obj.WeightEntryGUID.Equals(GUID));
            if (cheatMealEntry != null)
            {
                return true;
            }
            return false;
        }

        public CheatMealEntry GetCheatMealEntryByGUID(List<CheatMealEntry> CheatMealEntries, string GUID)
        {
            return CheatMealEntries.FirstOrDefault(obj => obj.GUID.Equals(GUID));
        }

        public CheatMealEntry GetCheatMealEntryByGUID(string GUID)
        {
            return GetCheatMeals().FirstOrDefault(obj => obj.GUID.Equals(GUID));
        }

        public List<CheatMealEntry> FindCheatMealEntriesInAscByUserName(string UserName)
        {
            return GetCheatMeals()
                .Where(obj => obj.UserName.Equals(UserName))
                .OrderBy(obj => obj.Date)
                .ToList();
        }

        public List<CheatMealEntry> FindCheatMealEntriesInDescByUserName(string UserName)
        {
            return GetCheatMeals()
                .Where(obj => obj.UserName.Equals(UserName))
                .OrderByDescending(obj => obj.Date)
                .ToList();
        }

        public CheatMealEntry FindLatestCheatMealEntryForUser(string UserName)
        {
            List<CheatMealEntry> cheatMealEntries = GetCheatMeals();
            if (cheatMealEntries.Count == 0)
            {
                return new CheatMealEntry();
            }

            return cheatMealEntries.Where(obj => obj.UserName.Equals(UserName)).OrderByDescending(obj => obj.Date).First();
        }

        public void DeleteCheatMealEntryByGUID(string GUID)
        {
            List<CheatMealEntry> cheatMealEntries = GetCheatMeals();
            CheatMealEntry cheatMealEntry = cheatMealEntries.FirstOrDefault(obj => obj.GUID.Equals(GUID));
            if (cheatMealEntry == null)
            {
                throw new RecordNotFoundExeption(GUID);
            }
            WeightEntryService.Instance.DeleteEntry(cheatMealEntry.WeightEntryGUID);
            cheatMealEntries.Remove(cheatMealEntry);
            DataStorage.SaveData(cheatMealEntries);
        }

        public void AddCheatMealEntry(CheatMealEntry cheatMealEntry, WeightEntry WeightEntry)
        {
            List<CheatMealEntry> cheatMealEntries = GetCheatMeals();
            WeightEntry = WeightEntryService.Instance.AddEntry(WeightEntry);

            cheatMealEntry.WeightEntryGUID = WeightEntry.GUID;
            cheatMealEntry.GUID = Guid.NewGuid().ToString();
            cheatMealEntries.Add(cheatMealEntry);
            DataStorage.SaveData(cheatMealEntries);
        }

        public void UpdateCheatMealEntry(CheatMealEntry cheatMealEntry, WeightEntry WeightEntry)
        {
            List<CheatMealEntry> cheatMealEntries = GetCheatMeals();
            CheatMealEntry cheatMealEntryToUpdate = cheatMealEntries.FirstOrDefault(obj => obj.GUID.Equals(cheatMealEntry.GUID));
            if (cheatMealEntryToUpdate == null)
            {
                throw new RecordNotFoundExeption(cheatMealEntry.GUID);
            }
            WeightEntryService.Instance.UpdateEntry(WeightEntry, cheatMealEntry.WeightEntryGUID);
            cheatMealEntryToUpdate.Date = cheatMealEntry.Date;
            cheatMealEntryToUpdate.Calories = cheatMealEntry.Calories;
            cheatMealEntryToUpdate.MealName = cheatMealEntry.MealName;
            DataStorage.SaveData(cheatMealEntries);
        }

    }
}

