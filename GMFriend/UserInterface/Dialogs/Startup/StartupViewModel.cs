using BusinessLogic;

using Caliburn.Micro;

using DataAccess.FileService;
using DataAccess.Notes.Group;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GMFriend.UserInterface.Dialogs.Startup
{
    public class StartupViewModel : Screen
    {
        private readonly INoteService noteService;
        private Group selectedGroup;

        public StartupViewModel(INoteService noteService)
        {
            NotifyOfPropertyChange(nameof(Groups));
            this.noteService = noteService;
        }

        public bool CanOnOk => SelectedGroup != null;
        public IEnumerable<Group> Groups => noteService.LoadGroups();

        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(CanOnOk));
            }
        }

        public void OnAddGroup(string title)
        {
            var group = new Group()
            {
                Title = title
            };

            noteService.AddNewGroup(group);
            NotifyOfPropertyChange(nameof(Groups));
        }

        public async void OnOk()
        {
            noteService.SetCurrentGroup(SelectedGroup);
            await TryCloseAsync(true);
        }
    }
}