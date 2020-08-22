using BusinessLogic.Notes.Markdown;

using DataAccess.Notes.Group;

using GMFriend.DependencyInjection;

using System.Windows;

namespace GMFriend.UserInterface.Tabs.Notes.Text
{
    public class TextNoteViewModel : NoteViewModel
    {
        private string input;
        private string output;
        private Visibility showInput = Visibility.Visible;
        private Visibility showOutput = Visibility.Collapsed;

        public TextNoteViewModel(INote note) : base(note)
        {
            DisplayName = "Notizen";
        }

        public string Input
        {
            get => input;
            set
            {
                input = value;
                Output = DI.Get<IMarkdownService>().ToStyledHTML(input);
                NotifyOfPropertyChange();
            }
        }

        public string Output
        {
            get => output;
            set
            {
                output = value;
                NotifyOfPropertyChange();
            }
        }

        public Visibility ShowInput
        {
            get => showInput;
            private set
            {
                showInput = value;
                NotifyOfPropertyChange();
            }
        }

        public Visibility ShowOutput
        {
            get => showOutput;
            private set
            {
                showOutput = value;
                NotifyOfPropertyChange();
            }
        }

        public void OnDisplay()
        {
            ShowInput = Visibility.Collapsed;
            ShowOutput = Visibility.Visible;
        }

        public void OnEdit()
        {
            ShowInput = Visibility.Visible;
            ShowOutput = Visibility.Collapsed;
        }
    }
}