using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryCleanSystem
{
    using System.Text.Json;

    public static class JsonDataManager<T>
    {
        public static List<T> Load(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public static void Save(string filePath, List<T> data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
