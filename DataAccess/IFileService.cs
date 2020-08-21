namespace DataAccess
{
    public interface IFileService
    {
        T Get<T>(string path, T def = null) where T : class;

        void Update<T>(string path, T value) where T : class;
    }
}