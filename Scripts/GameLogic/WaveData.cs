using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Object/WaveData")] 
public class WaveData : ScriptableObject 
{
	public List<Enemy> enemyList = new List<Enemy>();
	
	
}

