using NAudio.Wave;

using System;

namespace AudioGeneration.BusinessLogic
{
    internal class AudioFileReaderLazy : ISampleProvider
    {
        private AudioFileReader source;
        private float volumeBuffer = -1;

        public AudioFileReaderLazy(string filename)
        {
            Filename = filename;
            Source = null;
        }

        public TimeSpan CurrentTime
        {
            get => Source?.CurrentTime ?? TimeSpan.FromSeconds(0);
            set => Source.CurrentTime = value;
        }

        public TimeSpan TotalTime
        {
            get => Source?.TotalTime ?? TimeSpan.FromSeconds(0);
        }

        public float Volume
        {
            get => Source?.Volume ?? volumeBuffer;
            set
            {
                if (Source != null)
                {
                    Source.Volume = value;
                }
                else
                {
                    volumeBuffer = value;
                }
            }
        }

        public WaveFormat WaveFormat => WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
        private string Filename { get; }

        private AudioFileReader Source
        {
            get => source;
            set
            {
                source = value;
                if (volumeBuffer != -1.0)
                {
                    source.Volume = volumeBuffer;
                }
            }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            Source = Source ?? new AudioFileReader(Filename);
            return Source.Read(buffer, offset, count);
        }
    }
}