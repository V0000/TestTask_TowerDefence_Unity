using UnityEngine;

[Serializable]
public class Enemy
{
	public LevelData levelData;
	public int timeToNextSpawn;
	
	public Enemy(LevelData enemy, int time)
	{
		levelData = enemy;
		timeToNextSpawn = time;
	}
}
