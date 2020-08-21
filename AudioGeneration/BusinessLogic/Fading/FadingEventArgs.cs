using System;

namespace AudioGeneration.BusinessLogic.Fading
{
    public class FadingEventArgs : EventArgs
    {
        public FadingEventArgs(float currentScaling, bool fadedIn)
        {
            CurrentScaling = currentScaling;
            FadedIn = fadedIn;
        }

        public float CurrentScaling { get; }
        public bool FadedIn { get; }
        public bool FadedOut => !FadedIn;
    }
}