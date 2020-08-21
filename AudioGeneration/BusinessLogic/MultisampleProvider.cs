using NAudio.Wave;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AudioGeneration.BusinessLogic
{
    internal class MultiSampleProvider : ISampleProvider
    {
        public WaveFormat WaveFormat => Sources.FirstOrDefault()?.WaveFormat ?? WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
        private bool HasSources => Sources.Count > 0;
        private List<ISampleProvider> Sources { get; } = new List<ISampleProvider>();

        /// <exception cref="IOException">
        /// This exception is thrown when the given source waveformat doesnt match the currently
        /// used one.
        /// </exception>
        public void Add(ISampleProvider source)
        {
            var sourceWaveFormat = Sources.FirstOrDefault()?.WaveFormat;
            var newWaveFormat = source.WaveFormat;
            if (HasSources && WaveFormatsAreNotEqual(sourceWaveFormat, newWaveFormat))
                throw new IOException("The given ISampleProvider WaveFormat doesn't match the expected WaveFormat. Can't add it therefore!");
            lock (Sources)
            {
                Sources.Add(source);
            }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            ClearBuffer(buffer);
            FillBuffer(buffer, offset, count);
            return count;
        }

        private static void AddBufferRangeToBuffer(float[] sourceBuffer, float[] targetBuffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                targetBuffer[i + offset] += sourceBuffer[i + offset];
            }
        }

        private static void ClearBuffer(float[] buffer)
        {
            Array.Clear(buffer, 0, buffer.Length);
        }

        private void FillBuffer(float[] buffer, int offset, int count)
        {
            ISampleProvider[] tmpSources;
            lock (Sources)
            {
                tmpSources = Sources.ToArray();
            }

            var tmpBuffer = new float[buffer.Length];
            foreach (var provider in tmpSources)
            {
                FillBufferWithProviderData(tmpBuffer, offset, count, provider);
                AddBufferRangeToBuffer(tmpBuffer, buffer, offset, count);
            }
        }

        private void FillBufferWithProviderData(float[] buffer, int offset, int count, ISampleProvider dataProvider)
        {
            dataProvider.Read(buffer, offset, count);
        }

        private bool WaveFormatsAreNotEqual(WaveFormat sourceWaveFormat, WaveFormat newWaveFormat)
        {
            var samplerateDoesNotMatch = sourceWaveFormat.SampleRate != newWaveFormat.SampleRate;
            return samplerateDoesNotMatch;
        }
    }
}