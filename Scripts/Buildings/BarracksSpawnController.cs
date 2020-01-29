using UnityEngine;
using System.Collections;
using Units.Data;

namespace Buildings
{
    public class BarracksSpawnController : SpawnController
    {
        //public TypesOfUnits typesOfUnits;
        public int level = 1;
        public bool isWarriorDefault = true;
        public TypesOfUnits typesOfUnits;


        protected override void Start()
        {
            base.Start();
            selectedUnit = GetUnitForBuild();
            Debug.Log(selectedUnit);
            spawnTime = selectedUnit.trainingTime;
            StartCoroutine(SpawnPerTime(spawnTime));
            
        }


        protected UnitData GetUnitForBuild()
        {
            UnitData levelData;
            
            if (isWarriorDefault)
            {
                levelData = typesOfUnits.minionWarriors[0]; //level start with 1
            }

            else
            {
                levelData = typesOfUnits.minionArchers[0];
            }
            return levelData;
        }
    }
}
