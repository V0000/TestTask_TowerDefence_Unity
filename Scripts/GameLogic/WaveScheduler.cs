using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Scriptable Object/WaveData")] 
public class WaveScheduler : ScriptableObject {

	public List<Wave> scheduler = new List<SubList>();
}

