using AudioGeneration.BusinessLogic.Fading;
using System;

namespace AudioGeneration.BusinessLogic.Fading

{
    internal class FadeOut : IFadable
    {
        private readonly long samplesToFade;

        private long fadedSamples;

        public FadeOut(float fadingDuration, int sampleRate, float currentScaling)
        {
            samplesToFade = (long)(fadingDuration * sampleRate);
            fadedSamples = 0;
        }

        public event EventHandler<FadingEventArgs> FinishedFading;

        public float CurrentScaling => 1.0f - fadedSamples / (float)samplesToFade;

        public void Fade(float[] buffer, int offset, int count)
        {
            FadeBufferOut(buffer, offset, count);

            if (fadedSamples == samplesToFade)
                InvokeFinishedFading();
        }

        private void FadeBufferOut(float[] buffer, int offset, int count)
        {
            for (int sample = 0; sample < count; sample++)
            {
                UpdateFadedSamples();
                buffer[sample + offset] *= CurrentScaling;
            }
        }

        private void InvokeFinishedFading()
        {
            FinishedFading?.Invoke(this, new FadingEventArgs(CurrentScaling, false));
        }

        private void UpdateFadedSamples()
        {
            if (fadedSamples < samplesToFade)
                fadedSamples++;
        }
    }
}