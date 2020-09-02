namespace DataAccess.Settings
{
    public interface ISetting
    {
        string MusicEntriesKey { get; }
        string MusicFilePath { get; }
        string GroupEntriesKey { get;  }
    }
}