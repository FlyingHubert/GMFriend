using AudioGeneration.BusinessLogic;
using AudioGeneration.BusinessLogic.Fading;
using NAudio.Wave;
using System;

namespace AudioGeneration.BusinessLogic.Fading
{
    public class AudioFader : ISampleProvider
    {
        private IFadable currentFader = new NoFade(0);

        public AudioFader(ISampleProvider source)
        {
            Source = source.ToMono();
        }

        public event EventHandler<FadingEventArgs> FinishedFading;

        public WaveFormat WaveFormat => Source.WaveFormat;

        private IFadable CurrentFader
        {
            get => currentFader;
            set
            {
                if (currentFader != null)
                {
                    currentFader.FinishedFading -= OnFinishedFading;
                }
                currentFader = value;
                currentFader.FinishedFading += OnFinishedFading;
            }
        }

        private ISampleProvider Source { get; }

        public void FadeIn(float FadingDurationInSec = 3)
        {
            CurrentFader = new FadeIn(FadingDurationInSec, WaveFormat.SampleRate, CurrentFader.CurrentScaling);
        }

        public void FadeOut(float FadingDurationInSec = 3)
        {
            CurrentFader = new FadeOut(FadingDurationInSec, WaveFormat.SampleRate, CurrentFader.CurrentScaling);
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = Source.Read(buffer, offset, count);
            CurrentFader.Fade(buffer, offset, count);
            return samplesRead;
        }

        private void OnFinishedFading(object sender, FadingEventArgs args)
        {
            CurrentFader = new NoFade(args.CurrentScaling);
            FinishedFading?.Invoke(this, args);
        }
    }
}