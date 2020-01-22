using UnityEngine;
using System.Collections;

public class EnemySpawnController : SpawnController 
{
	private WaveScheduler waveScheduler;
	private List<Enemy> listOfEnemies;
	private int numInList = 0;

	override void Start () 
	{        
		base.Start ()
		listOfEnemies = waveScheduler.GetListOfEnemies();        
		NextEnemy();
		StartWave();
		
    }
	
	public void StartWave()
    {
		StartCoroutine(SpawnPerTime(spawnTime));
	}
	
	 public void NextEnemy()
    {
		selectedUnit = listOfEnemies[numInList].unitData;
		spawnTime = listOfEnemies[numInList].timeToNextSpawn;
		if (numInList<listOfEnemies.Count())
		{
			numInList++;
		}
		else 
		{
			StopCoroutine(SpawnPerTime(spawnTime));
		}
		
		
	}
	
    override protected UnitData GetUnitForBuild()
    {
        
        return selectedUnit;
    }
	
	
	override protected IEnumerator SpawnPerTime(float time)
    {
        while (true)        {
			
            yield return new WaitForSeconds(time);
            if (selectedUnit != null) 
			{
				CreateUnit();
			}
			NextEnemy();
			yield return new WaitForEndOfFrame();
        }
    }
    
}
