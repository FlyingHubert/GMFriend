namespace DataAccess.Music
{
    public class MusicEntity
    {
        public MusicEntity(string title, string path)
        {
            Title = title;
            Path = path;
        }

        public string Path { get; set; }
        public string Title { get; set; }
    }
}