namespace DataAccess.Settings
{
    public interface ISetting
    {
        string GroupFilePath { get; }
        string MusicConfigPath { get; }
        string MusicFilePath { get; }
    }
}