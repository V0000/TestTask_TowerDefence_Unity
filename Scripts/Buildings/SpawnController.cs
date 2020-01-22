using UnityEngine;
using System.Collections;

public abstract class SpawnController : MonoBehaviour 
{
    //ublic UnitData defaultUnit;
    protected UnitData selectedUnit;
    public TypesOfUnits typesOfUnits;
    private UnitBuilder builder;
    protected Vector3 spawnLocation;
    protected float spawnTime;

    protected virtual void Start () 
	{
        builder = GetComponent<UnitBuilder>();       
        spawnLocation = transform.position + Vector3.back;
        spawnLocation.y = 2.5f;
        selectedUnit = GetUnitForBuild();
		//spawnTime = selectedUnit.trainingTime;


    }

    public void CreateUnit()
    {
        builder.NewUnit(selectedUnit, spawnLocation);
    }

    protected virtual UnitData GetUnitForBuild()
    {        
        return selectedUnit;
    }
	
	protected virtual IEnumerator SpawnPerTime(float time)
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
