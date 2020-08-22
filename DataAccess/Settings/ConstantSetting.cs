namespace DataAccess.Settings
{
    public class ConstantSetting : ISetting
    {
        public string GroupFilesPath => @".\groups\";
        public string MusicConfigPath => @".\settings\musicEntries.json";

        public string MusicFilePath => @".\music\";
    }
}