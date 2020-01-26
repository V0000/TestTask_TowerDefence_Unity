using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public static class ObjectRegistry

{
	public static List<GameObject> enemies = new List<GameObject>();
	public static List<GameObject> minions = new List<GameObject>();
    public static GameObject fountain;
    public static GameObject couch;

    public static GameObject GetNearestTarget(Transform objectTransform, bool youIsEnemy)
	{
		GameObject nearestObject = null;
		float nearestDistance = Mathf.Infinity;
		float distance;
		List<GameObject> units = youIsEnemy? minions : enemies;
		foreach (GameObject target in units)
		{
			distance = Vector3.Distance(target.transform.position, objectTransform.position);
			if (distance < nearestDistance)
			{
				nearestDistance = distance;
				nearestObject = target;
			}
		}
        Debug.Log(nearestObject);
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