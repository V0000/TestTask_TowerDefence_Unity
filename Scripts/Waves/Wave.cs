using System;

namespace Waves
{
    [Serializable]
    public class Wave
    {
        public WaveData waveData;
        public int timeBeforeThisWaveInSeconds;
    }
}