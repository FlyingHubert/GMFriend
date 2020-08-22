using DataAccess.Notes.Group;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess.FileService
{
    public class JsonFileService : IFileService
    {
        public T Get<T>(string path, T def = null) where T : class
        {
            if (!File.Exists(path)
                || string.IsNullOrEmpty(File.ReadAllText(path))
                || File.ReadAllText(path) == "null")
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                var jsonToSerialize = JsonConvert.SerializeObject(def);
                File.WriteAllText(path, jsonToSerialize);
            }

            var json = File.ReadAllText(path);

            var result = JsonConvert.DeserializeObject<T>(json, new JsonINoteConverter());

            return result;
        }

        public IEnumerable<T> GetEnumerable<T>(string path) where T : class
        {
            return Get(path, Enumerable.Empty<T>());
        }

        public void Update<T>(string path, T value) where T : class
        {
            var json = JsonConvert.SerializeObject(value, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}