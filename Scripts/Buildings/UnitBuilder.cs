using System.Collections;
using UnityEngine;


public class UnitBuilder : MonoBehaviour
{
	public GameObject parent;    

    private GameObject unit;
    private Vector3 spawnLocation;

    /// <summary>
    /// Spawn unit on specific coordinates
    /// </summary>
    /// <param name="data">Type of unit to instantiate</param>
    /// <param name="spawnLocation">Where you will spawn unit</param>
    public void NewUnit(UnitData data, Vector3 spawnLocation)
    {
        BuildUnit(data);
        InstantiateUnit(unit, spawnLocation);
		AddUnitInRegistry(data, unit)

    }

    void BuildUnit(UnitData data)
	{	
		unit = data.prefab;
        SetMaterial(unit, data.material);
        
    }
	
	
	void InstantiateUnit(GameObject unit, Vector3 spawnLocation)
	{
		GameObject SpawnedUnit = Instantiate(unit);
		SpawnedUnit.transform.parent = parent.transform; 
		SpawnedUnit.transform.localPosition = spawnLocation;		
	}

    void SetMaterial(GameObject unit, Material material)
    {
        unit.GetComponent<Renderer>().material = material;
        unit.gameObject.transform.GetChild(0).GetComponent<Renderer>().material = material;
    }
	
	void AddUnitInRegistry(UnitData data,GameObject unit)
	{
		if (data.isEnemy)
		{
			UnitRegistry.enemies.Add(unit);
		}
		else
		{
			UnitRegistry.minions.Add(unit);
		}
	}

}