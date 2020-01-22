using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveScheduler", menuName = "Scriptable Object/WaveScheduler")] 
public class WaveScheduler : ScriptableObject 
{
	public List<Wave> scheduler = new List<SubList>();
	
	public List<Enemy> GetListOfEnemies()
	{
		public List<Enemy> listOfEnemies = new List<Enemy>();
		
		foreach (Wave wave in scheduler)
		{
			listOfEnemies.Add(new Enemy(null,0,wave.timeBeforeThisWaveInSeconds));
			foreach (Enemy enemy in wave.waveData.enemyList)
			{
				for(int i = 0; i < enemy.countOfUnits)
				{
					listOfEnemies.Add(enemy);
				}
			}	
			
		}
	}
}

