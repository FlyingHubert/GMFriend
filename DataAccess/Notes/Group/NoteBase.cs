using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Notes.Group
{
    public class NoteBase : INote
    {
        public NoteBase()
        {
            Type = this.GetType().Name;
        }

        public string Title { get; set; }
        public string Type { get; set; }
    }
}