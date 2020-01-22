using System;

[Serializable]
public class Enemy
{
	public UnitData unitData;
    public int countOfUnits;
	public int timeToNextSpawn;
	
	public Enemy(LevelData enemy,int count, int time)
	{
		levelData = enemy;
		countOfUnits = count;
		timeToNextSpawn = time;
	}
}
