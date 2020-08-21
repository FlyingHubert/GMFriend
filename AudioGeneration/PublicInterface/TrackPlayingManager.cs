using AudioGeneration.BusinessLogic;

using NAudio.Wave;

using System;
using System.IO;

namespace AudioGeneration.PublicInterface
{
    public static class TrackPlayingManager
    {
        static TrackPlayingManager()
        {
            OutputDevice = new WaveOutEvent();
            OutputDevice.Init(SampleProvider);
            OutputDevice.Play();
        }

        public static WaveOutEvent OutputDevice { get; set; }
        private static MultiSampleProvider SampleProvider { get; } = new MultiSampleProvider();

        public static void Dispose()
        {
            ((IDisposable)OutputDevice).Dispose();
        }

        public static Track Load(string filename)
        {
            if (File.Exists(filename))
            {
                var track = new Track(filename);
                SampleProvider.Add(track);
                return track;
            }
            else
            {
                throw new IOException($"The given audio file '{filename}' wasn't found");
            }
        }
    }
}