using System.Collections;
using UnityEngine;


public class UnitBuilder : MonoBehaviour
{
	public GameObject parent;
    public UnitData data1;

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

    }

    void BuildUnit(UnitData data)
	{	
		unit = data.prefab;
        SetMaterial(unit, data.material);
        
    }
	
	
	void InstantiateUnit(GameObject unit, Vector3 spawnLocation)
	{
		var SpawnedUnit = Instantiate(unit);
		SpawnedUnit.transform.parent = parent.transform; 
		SpawnedUnit.transform.localPosition = spawnLocation;
	}

    void SetMaterial(GameObject unit, Material material)
    {
        unit.GetComponent<Renderer>().material = material;
        unit.gameObject.transform.GetChild(0).GetComponent<Renderer>().material = material;
    }

}