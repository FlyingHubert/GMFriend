using Caliburn.Micro;

using DataAccess.Music;
using DataAccess.Settings;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GMFriend.UserInterface.Dialogs.AddMusic
{
    public class AddMusicViewModel : Screen
    {
        private readonly IMusicSource musicSource;
        private readonly ISetting settings;
        private string path;
        private string title;

        public AddMusicViewModel(IMusicSource musicSource, ISetting settings)
        {
            this.musicSource = musicSource;
            this.settings = settings;

            PropertyChanged += OnPropertyChanged;
        }

        public bool CanOK => File.Exists(Path) && !string.IsNullOrEmpty(Title);

        public string Path
        {
            get => path;
            set
            {
                path = value;
                NotifyOfPropertyChange();
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                NotifyOfPropertyChange();
            }
        }

        public async void OK()
        {
            var fileInfo = new FileInfo(Path);
            var targetFileName = System.IO.Path.Combine(settings.MusicFilePath, fileInfo.Name);
            Directory.CreateDirectory(settings.MusicFilePath);
            File.Copy(fileInfo.FullName, targetFileName);

            var entity = new MusicEntity(Title, targetFileName);
            musicSource.AddMusic(entity);

            await TryCloseAsync(true);
        }

        public void SelectPath()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Bitte Musikdatei auswählen";

            var result = dialog.ShowDialog();

            if (result == true)
            {
                Path = dialog.FileName;
            }
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Path) || e.PropertyName == nameof(Title))
            {
                NotifyOfPropertyChange(nameof(CanOK));
            }
        }
    }
}