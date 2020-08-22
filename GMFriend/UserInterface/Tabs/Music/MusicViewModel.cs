using AudioGeneration.PublicInterface;

using Caliburn.Micro;

using DataAccess.Music;

using GMFriend.DependencyInjection;
using GMFriend.UserInterface.Dialogs.AddMusic;

using GongSolutions.Wpf.DragDrop;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMFriend.UserInterface.Tabs.Music
{
    public class MusicViewModel : Screen, IDropTarget
    {
        private readonly IMusicSource musicSource;

        public MusicViewModel(IMusicSource musicSource)
        {
            DisplayName = "Musik";
            this.musicSource = musicSource;

            musicSource.MusicChanged += OnMusicChanged;
        }

        public IEnumerable<MusicEntity> AvailableMusic => musicSource.AvaiableMusic;

        public BindableCollection<PlayerViewModel> PlayableMusic { get; } = new BindableCollection<PlayerViewModel>();

        public async void AddNewMusic()
        {
            var wm = new WindowManager();

            var viewModel = DI.Get<AddMusicViewModel>();

            await wm.ShowDialogAsync(viewModel);
        }

        public void DragOver(IDropInfo dropInfo)
        {
            dropInfo.Effects = System.Windows.DragDropEffects.Copy;
        }

        public void Drop(IDropInfo dropInfo)
        {
            var entity = dropInfo.Data as MusicEntity;
            var track = TrackPlayingManager.Load(entity.Path, entity.Title);
            var viewModel = new PlayerViewModel(track);
            viewModel.RemoveThis += (s, a) => PlayableMusic.Remove(s as PlayerViewModel);
            PlayableMusic.Add(viewModel);
        }

        public void OnMusicChanged(object sender, EventArgs args)
        {
            NotifyOfPropertyChange(nameof(AvailableMusic));
        }
    }
}