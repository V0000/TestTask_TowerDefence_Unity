using UnityEngine;
using System.Collections;

public class EnemySpawnController : SpawnController 
{

    public int level = 1;
    public bool isWarriorDefault = true;
    private LevelData selectedUnit;    
    private int maxLevel;    
    private TypesOfUnits typesOfUnits;
    private UnitBuilder builder;
    private Vector3 spawnLocation;
    private float spawnTimer;


    void Start () 
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
