using DataAccess.Notes.Group;

using Newtonsoft.Json;

using System.IO;

namespace DataAccess.FileService
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

            var result = JsonConvert.DeserializeObject<T>(json, new JsonINoteConverter());

            return result;
        }

        public void Update<T>(string path, T value) where T : class
        {
            var json = JsonConvert.SerializeObject(value, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}