using NAudio.Wave;

namespace AudioGeneration.BusinessLogic
{
    internal class AudioStopper : ISampleProvider
    {
        public AudioStopper(ISampleProvider sampleProvider)
        {
            SampleProvider = sampleProvider;
        }

        public bool Play { get; set; } = false;

        public ISampleProvider SampleProvider { get; }
        public WaveFormat WaveFormat => SampleProvider.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            return Play ? SampleProvider.Read(buffer, offset, count) : count;
        }
    }
}