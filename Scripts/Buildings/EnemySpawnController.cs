using UnityEngine;
using System.Collections;

public class EnemySpawnController : SpawnController 
{

    private LevelData selectedUnit;      
    private TypesOfUnits typesOfUnits;
	private WaveScheduler waveScheduler;
    private UnitBuilder builder;
    private Vector3 spawnLocation;
    private float spawnTimer;


    override void Start () 
	{
		


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
