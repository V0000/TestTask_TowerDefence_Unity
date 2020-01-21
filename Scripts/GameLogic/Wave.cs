using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Scriptable Object/WaveData")] 
public class Wave
{
	public WaveData waveData;
	public int timeToNextWaveInSeconds;
}

