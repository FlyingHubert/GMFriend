using DataAccess.FileService;

using LiteDB;

using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class SimplePersistenceService : IPersistenceService
    {
        private readonly JsonFileService jsonFileService;

        public SimplePersistenceService(JsonFileService jsonFileService = null)
        {
            this.jsonFileService = jsonFileService ?? new JsonFileService();
        }

        public void AddToCollection<TValue>(string key, TValue value)
        {
            using (var db = CreateNewDB())
            {
                var collection = db.GetCollection<TValue>(key);
                collection.Upsert(value);
                db.Commit();
            }
        }

        public TValue Get<TValue>(string key)
        {
            return jsonFileService.Get<TValue>(key);
        }

        public IEnumerable<TValue> GetCollection<TValue>(string key)
        {
            using (var db = CreateNewDB())
            {
                var collection = db.GetCollection<TValue>(key);
                var items = collection.FindAll().ToArray();

                return items;
            }
        }

        public void Set<TValue>(string key, TValue value)
        {
            jsonFileService.Update(key, value);
        }

        private static LiteDatabase CreateNewDB()
        {
            return new LiteDatabase("data.db");
        }
    }
}