using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Notes.Group
{
    public class Group
    {
        public IEnumerable<Chapter> Chapters { get; set; }
        public string Title { get; set; }
    }
}