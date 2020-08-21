using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Settings : ISetting
    {
        public string MusicConfigPath => @".\settings\musicEntries.json";

        public string MusicFilePath => @".\music\";
    }
}