using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public int level = 1;
    public bool isWarriorDefault = true;
    private LevelData selectedUnit;    
    private int maxLevel;    
    private TypesOfUnits typesOfUnits;
    private UnitBuilder builder;
    private Vector3 spawnLocation;
    private float spawnTimer;


    // Use this for initialization
    void Start () {
        builder = GetComponent<UnitBuilder>();       
        spawnLocation = transform.position + Vector3.back;
        selectedUnit = GetUnitForBuild();
        maxLevel = typesOfUnits.minionWarriors.Length;
        spawnTimer = selectedUnit.trainingTime;
        StartCoroutine(SpawnPerTime());

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator SpawnPerTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            CreateUnit();
        }
    }

    public void CreateUnit()
    {
        builder.NewUnit(selectedUnit, spawnLocation);
    }

    public LevelData GetUnitForBuild()
    {
        LevelData levelData;
        if (isWarriorDefault)
        {
            levelData = typesOfUnits.minionWarriors[level-1]; //level start with 1, but array with 0
         }

        else
        {
            levelData = typesOfUnits.minionArchers[level-1];
        }
        return levelData;
    }
}
