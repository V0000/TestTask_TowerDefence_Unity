using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Scriptable Object/WaveData")] 
public class WaveScheduler : ScriptableObject 
{
	public List<Wave> scheduler = new List<SubList>();
	
	public List<Enemy> GetListOfEnemies()
	{
		public List<Enemy> listOfEnemies = new List<Enemy>();
		
		foreach (Wave wave in scheduler)
		{
			foreach (Enemy enemy in wave.waveData.enemyList)
			{
				listOfEnemies.Add(enemy);
			}	
			listOfEnemies.Add(new Enemy(null,wave.timeToNextWaveInSeconds));
		}
	}
}

