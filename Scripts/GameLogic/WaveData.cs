using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Scriptable Object/WaveData")] 
public class WaveData : ScriptableObject 
{
	public List<Enemy> enemyList = new List<Enemy>();
	
	
}

