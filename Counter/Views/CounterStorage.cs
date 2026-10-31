using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Counter.Views
{
    internal class CounterStorage
    {
        private readonly string _filepath =
            Path.Combine(FileSystem.AppDataDirectory, "counters.json");

        public void Save(IEnumerable<CounterModel> counters)
        {
            string json = JsonSerializer.Serialize(counters);
            File.WriteAllText(_filepath, json);
        }


        public List<CounterModel> Load()
        {
            try
            {
                if (!File.Exists(_filepath))
                {
                    return new List<CounterModel>();
                }

                string json = File.ReadAllText(_filepath);
                return JsonSerializer.Deserialize<List<CounterModel>>(json) ?? new List<CounterModel>();
            }
            catch (Exception)
            {
                return new List<CounterModel>();
            }


        }
            
    }
}
