using System.Collections;
using UnityEngine;


public class BuildSidebar : MonoBehaviour
{
	public Vector3 spawnLocation = transform.position + new Vector3(0f, 2f, 0f);
	private GameObject unit;
	
	void BuildUnit(LevelData data)
	{	
		unit = data.prefab;
		LevelData unitData = unit.AddComponent(typeof(LevelData)) as LevelData;
		
		
	}
	
	
	void InstantiateUnit(unit)
	{
		var SpawnedUnit = Instantiate(unit);
		SpawnedUnit.SetParent(Units); 
		SpawnedUnit.transform.localPosition = spawnLocation;
	}
	
}