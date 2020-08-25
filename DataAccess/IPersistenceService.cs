using System.Collections.Generic;

namespace DataAccess
{
    public interface IPersistenceService
    {
        void AddToCollection<TValue>(string key, TValue value);

        TValue Get<TValue>(string key);

        IEnumerable<TValue> GetCollection<TValue>(string key);

        void Set<TValue>(string key, TValue value);
    }
}