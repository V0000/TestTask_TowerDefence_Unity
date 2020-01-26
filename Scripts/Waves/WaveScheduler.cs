using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveScheduler", menuName = "Scriptable Object/WaveScheduler")] 
public class WaveScheduler : ScriptableObject 
{
	public List<Wave> scheduler = new List<Wave>();

    public List<Enemy> GetListOfEnemies()
    {
        List<Enemy> listOfEnemies = new List<Enemy>();
        foreach (Wave wave in scheduler)
        {
            listOfEnemies.Add(new Enemy(null,0,wave.timeBeforeThisWaveInSeconds));

            foreach (Enemy enemy in wave.waveData.enemyList)
            {
                for (int i = 0; i < enemy.countOfUnits; i++)
                {
                    listOfEnemies.Add(enemy);                    
                }
            }

        }
        Debug.Log("In listOfEnemies:" + listOfEnemies.Count);
        foreach (Enemy e in listOfEnemies) Debug.Log(e.timeToNextSpawn);
        return listOfEnemies;


    }
}

