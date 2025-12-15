using System.Collections.Generic;
using System.IO;
using FitnessTrackerApp.Utility;
using Newtonsoft.Json;

namespace FitnessTrackerApp.Service
{

    public class DataStorage
    {


        private static readonly string FolderPath = Util.JSON_STORAGE_PATH;

        public static void SaveData<T>(List<T> dataList)
        {
            string filePath = GetFilePath<T>();
            string jsonText = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            File.WriteAllText(filePath, jsonText);
        }

        private static string GetFilePath<T>()
        {
            string typeName = typeof(T).Name;
            string fileName = typeName + ".json";
            return Path.Combine(FolderPath, fileName);
        }

        public static List<T> LoadData<T>()
        {
            string filePath = GetFilePath<T>();

            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            string jsonText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonText) ?? new List<T>();
        }
    }
}