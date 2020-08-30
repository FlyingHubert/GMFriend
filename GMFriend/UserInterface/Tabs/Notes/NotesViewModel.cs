using BusinessLogic;
using BusinessLogic.Notes.Markdown;

using Caliburn.Micro;

using DataAccess.Notes.Group;

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
        private readonly INoteService noteService;

        public NotesViewModel(INoteService noteService)
        {
            this.noteService = noteService;
            Chapters = new BindableCollection<ChapterViewModel>(from chapter in noteService.Chapters
                                                                select new ChapterViewModel(chapter));
        }

        public BindableCollection<ChapterViewModel> Chapters { get; }

        public void OnAddChapter()
        {
            throw new NotImplementedException();

            noteService.AddChapter(new Chapter());
        }
    }
}