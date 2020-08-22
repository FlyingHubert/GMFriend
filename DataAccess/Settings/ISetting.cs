namespace DataAccess.Settings
{
    public interface ISetting
    {
        string GroupFilesPath { get; }
        string MusicConfigPath { get; }
        string MusicFilePath { get; }
    }
}