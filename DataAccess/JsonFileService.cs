using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class JsonFileService : IFileService
    {
        public T Get<T>(string path, T def = null) where T : class
        {
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                var jsonToSerialize = JsonConvert.SerializeObject(def);
                File.WriteAllText(path, jsonToSerialize);
            }

            var json = File.ReadAllText(path);

            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }

        public void Update<T>(string path, T value) where T : class
        {
            var json = JsonConvert.SerializeObject(value, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}