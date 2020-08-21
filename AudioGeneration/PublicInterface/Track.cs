using AudioGeneration.BusinessLogic;
using AudioGeneration.BusinessLogic.Fading;

using NAudio.Wave;

using System;
using System.IO;

namespace AudioGeneration.PublicInterface
{
    /// <summary>
    /// This class represent a playable track and offers an public interface to be used from outside
    /// the package. Just instantiate or get it from a music folder. This class offers a nice set of
    /// methods to play and fade music files.
    /// </summary>
    public class Track : ISampleProvider
    {
        internal Track(string filename, string title = null)
        {
            Reader = new AudioFileReaderLazy(filename);
            Title = string.IsNullOrEmpty(title) ? new FileInfo(filename).Name : title;
            Stopper = new AudioStopper(Reader);
            Fader = new AudioFader(Stopper);
            Fader.FinishedFading += OnFinishedFading;
        }

        public TimeSpan CurrentTime
        {
            get => Reader.CurrentTime;
            set => Reader.CurrentTime = value;
        }

        public bool IsPlaying => Stopper.Play;
        public string Title { get; }

        public TimeSpan TotalTime => Reader.TotalTime;

        public float Volume
        {
            get => Reader.Volume;
            set => Reader.Volume = value;
        }

        public WaveFormat WaveFormat => Fader.WaveFormat;
        private AudioFader Fader { get; }
        private AudioFileReaderLazy Reader { get; }
        private AudioStopper Stopper { get; }

        public void Pause()
        {
            Fader.FadeOut();
        }

        public void Play()
        {
            Stopper.Play = true;
            Fader.FadeIn();
        }

        public int Read(float[] buffer, int offset, int count)
        {
            return Fader.Read(buffer, offset, count);
        }

        private void OnFinishedFading(object sender, FadingEventArgs args)
        {
            if (args.FadedOut)
            {
                Stopper.Play = false;
            }
        }
    }
}