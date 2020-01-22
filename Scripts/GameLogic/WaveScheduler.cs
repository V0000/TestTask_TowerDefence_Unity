using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveScheduler", menuName = "Scriptable Object/WaveScheduler")] 
public class WaveScheduler : ScriptableObject 
{
	public List<Wave> schedule = new List<Wave>();

    public void SheduleToList()
    {
    }

}

