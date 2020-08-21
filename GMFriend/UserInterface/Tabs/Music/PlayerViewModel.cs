using AudioGeneration.PublicInterface;

using Caliburn.Micro;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GMFriend.UserInterface.Tabs.Music
{
    public class PlayerViewModel : PropertyChangedBase
    {
        private readonly Track track;

        private Timer timer;

        public PlayerViewModel(Track track)
        {
            this.track = track;

            Title = track.Title;

            timer = new Timer(1000);
            timer.Elapsed += (o, a) =>
            {
                NotifyOfPropertyChange(nameof(CurrentTime));
                NotifyOfPropertyChange(nameof(TotalTime));
            };
            timer.AutoReset = true;
            timer.Start();
        }

        public event EventHandler RemoveThis;

        public double CurrentTime
        {
            get => track.CurrentTime.TotalMinutes;
            set => track.CurrentTime = TimeSpan.FromMinutes(value);
        }

        public string Title { get; }
        public double TotalTime => track.TotalTime.TotalMinutes;

        public int Volume
        {
            get => (int)Math.Round(track.Volume * 100);
            set
            {
                track.Volume = value / 100.0f;
                NotifyOfPropertyChange();
            }
        }

        public void OnDelete()
        {
            timer.Stop();
            track.Pause();
            RemoveThis?.Invoke(this,
                                 EventArgs.Empty);
        }

        public void OnPause() => track.Pause();

        public void OnPlay()
        {
            track.Play();
            NotifyOfPropertyChange(nameof(Volume));
        }
    }
}