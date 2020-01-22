using UnityEngine;
using System.Collections;

public class BarracksSpawnController : SpawnController 
{

    public int level = 1;
    public bool isWarriorDefault = true;   
    //private int maxLevel;

    public override void Start () {

        base.Start();
       // maxLevel = typesOfUnits.minionWarriors.Length;        

    }
	
	
    override public UnitData GetUnitForBuild()
    {
        UnitData levelData;
        if (isWarriorDefault)
        {
            levelData = typesOfUnits.minionWarriors[level-1]; //level start with 1, but array with 0
         }

        else
        {
            levelData = typesOfUnits.minionArchers[level-1];
        }
        return levelData;
    }
}
