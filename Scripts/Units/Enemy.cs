using System;

[Serializable]
public class Enemy
{
	public UnitData levelData;
    public int countOfUnits;
	public int timeToNextSpawn;
	
	public Enemy(LevelData enemy, int time)
	{
		levelData = enemy;
		timeToNextSpawn = time;
	}
}
