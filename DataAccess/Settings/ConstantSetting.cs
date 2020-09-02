namespace DataAccess.Settings
{
    public class ConstantSetting : ISetting
    {
        public string GroupFilePath => @".\groups.json";

        public string MusicFilePath => @".\music\";

        public string MusicEntriesKey => "MusicEntries";

        public string GroupEntriesKey => "Groups";
    }
}