using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class JsonFileService
    {
        private readonly string fileName;

        public JsonFileService(string fileName = "settings.json")
        {
            this.fileName = fileName;
        }

        public T Get<T>(string key)
        {
            if (!File.Exists(fileName))
            {
                var dir = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var jsonToSerialize = JsonConvert.SerializeObject(new Dictionary<string, object>());
                File.WriteAllText(fileName, jsonToSerialize);
            }

            var dict = ReadDictFromJson();

            return (T)dict[key];
        }

        public void Update<T>(string key, T value)
        {
            var dict = ReadDictFromJson();
            dict[key] = value;
            WriteDictToJson(dict);
        }

        private Dictionary<string, object> ReadDictFromJson()
        {
            var json = File.ReadAllText(fileName);
            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            return result;
        }

        private void WriteDictToJson(Dictionary<string, object> dict)
        {
            var json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}