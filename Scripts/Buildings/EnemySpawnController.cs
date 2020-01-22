using UnityEngine;
using System.Collections;

public class EnemySpawnController : SpawnController 
{

	private WaveScheduler waveScheduler;
	private List<Enemy> listOfEnemies;

    override void Start () {
        
		base.Start ()
		listOfEnemies = waveScheduler.GetListOfEnemies();
        

    }
	

    override public LevelData GetUnitForBuild()
    {
        LevelData levelData;
        if (isWarriorDefault)
        {
            levelData = typesOfUnits.minionWarriors[level-1]; 
         }

        else
        {
            levelData = typesOfUnits.minionArchers[level-1];
        }
        return levelData;
    }
}
