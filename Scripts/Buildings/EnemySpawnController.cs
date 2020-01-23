using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnController : SpawnController 
{
	public WaveScheduler waveScheduler;
	private List<Enemy> listOfEnemies;
	private int numInList = 0;

	override protected void Start () 
	{
        base.Start();
		listOfEnemies = waveScheduler.GetListOfEnemies();
		StartNextEnemy();
		
    }
	

	
	 public void StartNextEnemy()
    {

        
        if (numInList<listOfEnemies.Count)
		{
            selectedUnit = listOfEnemies[numInList].unitData;
            spawnTime = listOfEnemies[numInList].timeToNextSpawn;
            numInList++;
            StartCoroutine(SpawnPerTime(spawnTime));
        }	
		
	}
	
    override protected UnitData GetUnitForBuild()
    {
        
        return selectedUnit;
    }
	
	
	override protected IEnumerator SpawnPerTime(float time)
    { 		
            yield return new WaitForSeconds(time);
            if (selectedUnit != null) 
			{
				CreateUnit();
			}
			StartNextEnemy();
    }
    
}
