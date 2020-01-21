using UnityEngine;
using System.Collections;

public abstract class SpawnController : MonoBehaviour 
{
    public LevelData defaultUnit;
	private LevelData selectedUnit;	
    private TypesOfUnits typesOfUnits;
    private UnitBuilder builder;
    private Vector3 spawnLocation;
    private float spawnTime;

    void Start () 
	{
        builder = GetComponent<UnitBuilder>();       
        spawnLocation = transform.position + Vector3.back;
        selectedUnit = GetUnitForBuild();
		spawnTime = selectedUnit.trainingTime;
        StartCoroutine(SpawnPerTime(spawnTime));

    }

    public void CreateUnit()
    {
        builder.NewUnit(selectedUnit, spawnLocation);
    }

    public LevelData GetUnitForBuild()
    {        
        return defaultUnit;
    }
	
	IEnumerator SpawnPerTime(float time)
    {
        while (true)        {
			
            yield return new WaitForSeconds(time);
            if (selectedUnit != null) 
			{
				CreateUnit();
			}
        }
    }
}
