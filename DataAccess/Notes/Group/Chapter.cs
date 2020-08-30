using System.Collections;
using System.Collections.Generic;

namespace DataAccess.Notes.Group
{
    public class Chapter
    {
        public IEnumerable<INote> Notes { get; set; }
        public string Title { get; set; }
    }
}