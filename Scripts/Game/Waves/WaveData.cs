using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Scriptable Object/WaveData")] 
public class WaveData : ScriptableObject {

	public int countOfWarriors;
	public int countOfArchers;
	public int countOfBosses;
	public float timeToNextWave;
}

