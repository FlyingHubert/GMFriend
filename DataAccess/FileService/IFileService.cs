using System.Collections.Generic;

namespace DataAccess.FileService
{
    public interface IFileService
    {
        T Get<T>(string path, T def = null) where T : class;

        IEnumerable<T> GetEnumerable<T>(string path) where T : class;

        void Update<T>(string path, T value) where T : class;
    }
}