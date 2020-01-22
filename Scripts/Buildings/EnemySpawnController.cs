using UnityEngine;
using System.Collections;

public class EnemySpawnController : SpawnController 
{
	public WaveScheduler waveScheduler;

	

    override public UnitData GetUnitForBuild()
    {


        return selectedUnit;
    }
    
}
