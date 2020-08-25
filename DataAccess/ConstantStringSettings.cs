using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ConstantStringSettings : ISetting
    {
        public string MusicEntriesKey => "musicEntries";

        public string MusicFilePath => @".\music\";
    }
}