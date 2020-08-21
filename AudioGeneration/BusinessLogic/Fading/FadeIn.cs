using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AudioGeneration.BusinessLogic.Fading
{
    internal class FadeIn : IFadable
    {
        private long fadedSamples;
        private long samplesToFade;

        public FadeIn(float durationInSec, int sampleRate, float currentScaling)
        {
            samplesToFade = (long)(durationInSec * sampleRate);
            fadedSamples = (long)currentScaling * samplesToFade;
        }

        public event EventHandler<FadingEventArgs> FinishedFading;

        public float CurrentScaling => fadedSamples / (float)samplesToFade;

        public void Fade(float[] buffer, int offset, int count)
        {
            FadeBufferIn(buffer, offset, count);

            if (fadedSamples == samplesToFade)
            {
                InvokeFinishedFading();
            }
        }

        private void FadeBufferIn(float[] buffer, int offset, int count)
        {
            for (int sample = 0; sample < count; sample++)
            {
                UpdateFadedSamples();
                buffer[sample + offset] *= CurrentScaling;
            }
        }

        private void InvokeFinishedFading()
        {
            FinishedFading?.Invoke(this, new FadingEventArgs(CurrentScaling, true));
        }

        private void UpdateFadedSamples()
        {
            if (fadedSamples < samplesToFade)
                fadedSamples++;
        }
    }
}