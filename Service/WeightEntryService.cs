using FitnessTrackerApp.Exceptions;
using FitnessTrackerApp.Model;
using System;
using System.Collections.Generic;

namespace FitnessTrackerApp.Service
{
    public class WeightEntryService
    {
        private List<WeightEntry> GetAllEntries()
        {
            return DataStorage.LoadData<WeightEntry>();
        }

        public List<WeightEntry> GetEntriesAscending(string username)
        {
            List<WeightEntry> allEntries = GetAllEntries();
            List<WeightEntry> entries = new List<WeightEntry>();

            foreach (WeightEntry entry in allEntries)
            {
                if (string.Equals(entry.UserName, username, System.StringComparison.OrdinalIgnoreCase))
                {
                    entries.Add(entry);
                }
            }

            entries.Sort((a, b) => a.Date.CompareTo(b.Date));
            return entries;
        }

        public void AddExistingEntry(WeightEntry weight)
        {
            List<WeightEntry> allWeights = DataStorage.LoadData<WeightEntry>();
            allWeights.Add(weight);
            DataStorage.SaveData(allWeights);
        }


        public List<WeightEntry> GetEntriesDescending(string username)
        {
            List<WeightEntry> ascending = GetEntriesAscending(username);
            ascending.Reverse();
            return ascending;
        }

        public WeightEntry GetLatestEntry(string username)
        {
            List<WeightEntry> entries = GetEntriesDescending(username);

            if (entries.Count == 0)
            {
                return new WeightEntry();
            }

            return entries[0];
        }

        public WeightEntry GetEntryByGuid(string guid)
        {
            List<WeightEntry> allEntries = GetAllEntries();

            foreach (WeightEntry entry in allEntries)
            {
                if (entry.GUID == guid)
                {
                    return entry;
                }
            }

            return null;
        }

        public WeightEntry AddNewEntry(WeightEntry newEntry)
        {
            List<WeightEntry> allEntries = GetAllEntries();

            newEntry.GUID = Guid.NewGuid().ToString();

            allEntries.Add(newEntry);
            DataStorage.SaveData(allEntries);

            return newEntry;
        }

        public void DeleteEntry(string guid)
        {
            List<WeightEntry> allEntries = GetAllEntries();
            WeightEntry entry = GetEntryByGuid(guid);

            if (entry == null)
            {
                throw new RecordNotFoundExeption(guid);
            }

            allEntries.Remove(entry);
            DataStorage.SaveData(allEntries);
        }

        public void UpdateEntry(WeightEntry updatedEntry, string guid)
        {
            List<WeightEntry> allEntries = GetAllEntries();
            WeightEntry entry = GetEntryByGuid(guid);

            if (entry == null)
            {
                throw new RecordNotFoundExeption(guid);
            }

            entry.Weight = updatedEntry.Weight;
            entry.Date = updatedEntry.Date;

            DataStorage.SaveData(allEntries);
        }
    }
}