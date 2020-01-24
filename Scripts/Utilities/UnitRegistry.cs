using System.Collections.Generic;
using UnityEngine;


public static class UnitRegistry

{
	public static List<GameObject> enemies = new List<GameObject>();
	public static List<GameObject> minions = new List<GameObject>();	
	
	public static GameObject GetNearestTarget(Transform objectTransform, bool youIsEnemy)
	{
		GameObject nearestObject;
		float nearestDistance = Math.Infinite;
		float distance;
		List<GameObject> units = youIsEnemy? minions : enemies;
		foreach (GameObject target in units)
		{
			distance = Vector3.Distance(target.position, objectTransform.position);
			if (distance < nearestDistance)
			{
				nearestDistance = distance;
				nearestObject = target;
			}
		}
		return nearestObject;
	}
	
	public static bool TargetIsExist(bool youIsEnemy)
	{
		List<GameObject> units = youIsEnemy? minions : enemies;
		if (units.Any()) 
		{
			return true;			
		}
		return false;
	}
}