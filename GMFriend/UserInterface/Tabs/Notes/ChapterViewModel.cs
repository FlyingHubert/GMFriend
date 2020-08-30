using DataAccess.Notes.Group;

using System;

namespace GMFriend.UserInterface.Tabs.Notes
{
    public class ChapterViewModel : Caliburn.Micro.Conductor<NoteViewModel>
    {
        private Chapter chapter;

        public ChapterViewModel(Chapter chapter)
        {
            this.chapter = chapter;
        }

        public void OnAddNote()
        {
            System.Console.WriteLine("Hier müsste ein Notiz hinzugefügt werden...");
            throw new NotImplementedException();
        }
    }
}