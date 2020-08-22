using BusinessLogic.Notes.Markdown;

using Caliburn.Micro;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GMFriend.UserInterface.Tabs.Notes
{
    public class NotesViewModel : Screen
    {
        private readonly IMarkdownService markdownService;
        private string input;
        private string output;
        private Visibility showInput = Visibility.Visible;
        private Visibility showOutput = Visibility.Collapsed;

        public NotesViewModel(IMarkdownService markdownService)
        {
            DisplayName = "Notizen";
            this.markdownService = markdownService;
        }

        public string Input
        {
            get => input;
            set
            {
                input = value;
                Output = markdownService.ToStyledHTML(input);
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