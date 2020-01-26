using System;

[Serializable]
public class Enemy
{
	public UnitData unitData;
    public float countOfUnits;
	public float timeToNextSpawn;
	
	public Enemy(UnitData enemy,int count, int time)
	{
        unitData = enemy;
		countOfUnits = count;
		timeToNextSpawn = time;
	}
}
