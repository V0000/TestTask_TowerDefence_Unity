using UnityEngine;
using System.Collections;
using Units.Data;

namespace Buildings
{
	/// <summary>
    /// Class for buildings that can build minions
    /// </summary>
    public class BarracksSpawnController : SpawnController
    {
		//Current level of building
        public int level = 1;
        public bool isWarriorDefault = true;
		//All availible types of units
        public TypesOfUnits typesOfUnits;


        protected override void Start()
        {
            base.Start();
            selectedUnit = GetUnitForBuild();
            spawnTime = selectedUnit.trainingTime;
            StartCoroutine(SpawnPerTime(spawnTime));
            
        }

		/// <summary>
		/// Get UnitData for build according to level of building
		/// </summary>
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
