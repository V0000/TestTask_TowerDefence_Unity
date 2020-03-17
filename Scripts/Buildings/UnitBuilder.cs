using System;
using System.Collections;
using Units;
using Units.Attack;
using Units.Data;
using Units.Health;
using UnityEngine;
using Utilities;

namespace Buildings
{
    public class UnitBuilder : MonoBehaviour
    {		
		[Tooltip("Empty GameObject for group created units")]
        public GameObject parent;
		[Tooltip("Empty GameObject for group dead units")]
        public GameObject parentForDead;
		//Unit, that will be builded
        private GameObject unit;
		//Coordinates where unit will be instantiated
        private Vector3 spawnLocation;
        //Сomponents on unit that will be customized
		private NavMeshAgent navMeshAgent;
        private UnitBehaviour unitBehaviour;
        private HealthController healthController;
        private AttackController attackController;
        

        /// <summary>
        /// Spawn unit on specific coordinates
        /// </summary>
        /// <param name="data">Data for build unit</param>
        /// <param name="spawnLocation">Where you will spawn unit</param>
        public void NewUnit(UnitData data, Vector3 spawnLocation)
        {
            BuildUnit(data, spawnLocation);
            
        }

        /// <summary>
        /// Build unit from prefab and set settings from UnitData
        /// </summary>
        /// <param name="data">List of settings</param>
        void BuildUnit(UnitData data, Vector3 spawnLocation)
        {
            unit = InstantiateUnit(data.prefab, spawnLocation);
            unit.name = data.nameOfUnit+ '_' + ObjectRegistry.allUnitsCount++.ToString();
            //Debug.Log(unit.name + " is start build");

            //set appearance settings
            SetMaterial(unit, data.material);

            

            //set move settings
            navMeshAgent = unit.GetComponent<NavMeshAgent>();
            navMeshAgent.speed = data.speed;
            navMeshAgent.stoppingDistance = data.attackDistance;

            //set behavior settings
            unitBehaviour = unit.GetComponent<UnitBehaviour>();
            unitBehaviour.isEnemy = data.isEnemy;

            //set health settings
            healthController = unit.GetComponent<HealthController>();
            healthController.MaxHealth = data.maxHealth;
            healthController.Health = data.maxHealth;
            healthController.Armor = data.armor;
            healthController.Gold = data.gold;
            healthController.Xp = data.xp;
            healthController.deadUnit = data.deadUnitPrefab;
            healthController.parentForDead = parentForDead;
            healthController.isEnemy = data.isEnemy;            

            //set attack settings
            attackController = unit.GetComponent<AttackController>();
            attackController.Attack = data.attack;
            attackController.AttackSpeed = data.attackSpeed;
            attackController.AttackDistance = data.attackDistance;
        }

        /// <summary>
        /// Set builded unit on coordinates
        /// </summary>
        GameObject InstantiateUnit(GameObject unit, Vector3 spawnLocation)
        {
            GameObject spawnedUnit = Instantiate(unit);
			//Set parent for group instantiated units
            spawnedUnit.transform.parent = parent.transform;
            spawnedUnit.transform.localPosition = spawnLocation;
            return spawnedUnit;
        }
		
        /// <summary>
        /// Set material for unit and his childs
        /// </summary>
        void SetMaterial(GameObject unit, Material material)
        {
            unit.GetComponent<Renderer>().material = material;
            unit.gameObject.transform.Find("Head").GetComponent<Renderer>().material = material;
            unit.gameObject.transform.Find("Marker").GetComponent<Renderer>().material = material;

        }


    }
}