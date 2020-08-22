namespace DataAccess.Settings
{
    public class ConstantSetting : ISetting
    {
        public string GroupFilePath => @".\groups.json";
        public string MusicConfigPath => @".\settings\musicEntries.json";

        public string MusicFilePath => @".\music\";
    }
}