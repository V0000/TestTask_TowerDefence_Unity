using UnityEngine;
using System.Collections;
using Units.Data;

namespace Buildings
{
    public class BarracksSpawnController : SpawnController
    {
        public TypesOfUnits typesOfUnits;
        public int level = 1;
        public bool isWarriorDefault = true;


        protected override void Start()
        {
            base.Start();
            spawnTime = selectedUnit.trainingTime;
            StartCoroutine(SpawnPerTime(spawnTime));
        }


        override protected UnitData GetUnitForBuild()
        {
            UnitData levelData;
            if (isWarriorDefault)
            {
                levelData = typesOfUnits.minionWarriors[level - 1]; //level start with 1
            }

            else
            {
                levelData = typesOfUnits.minionArchers[level - 1];
            }
            return levelData;
        }
    }
}
