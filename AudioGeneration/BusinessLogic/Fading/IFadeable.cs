using AudioGeneration.BusinessLogic.Fading;
using System;

namespace AudioGeneration.BusinessLogic.Fading
{
    internal interface IFadable
    {
        event EventHandler<FadingEventArgs> FinishedFading;

        float CurrentScaling { get; }

        void Fade(float[] buffer, int offset, int count);
    }
}