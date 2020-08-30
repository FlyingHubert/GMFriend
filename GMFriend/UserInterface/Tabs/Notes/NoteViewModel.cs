using Caliburn.Micro;

using DataAccess.Notes.Group;

namespace GMFriend.UserInterface.Tabs.Notes
{
    public class NoteViewModel : Screen
    {
        private readonly INote note;

        public NoteViewModel(INote note)
        {
            this.note = note;
            DisplayName = note.Title;
        }

        protected INote Note => note;
    }
}