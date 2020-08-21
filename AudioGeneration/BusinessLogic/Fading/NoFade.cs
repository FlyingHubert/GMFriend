using AudioGeneration.BusinessLogic.Fading;
using System;

namespace AudioGeneration.BusinessLogic.Fading
{
    internal class NoFade : IFadable
    {
        public NoFade(float scaling = 1.0f)
        {
            CurrentScaling = scaling;
        }

        public event EventHandler<FadingEventArgs> FinishedFading { add { } remove { } }

        public float CurrentScaling { get; }

        public void Fade(float[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                buffer[i + offset] *= CurrentScaling;
            }
        }
    }
}