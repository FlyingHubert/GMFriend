using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
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