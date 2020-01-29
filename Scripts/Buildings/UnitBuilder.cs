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
        public GameObject parent;
        public GameObject parentForDead;
        private GameObject unit;
        private Vector3 spawnLocation;
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
            BuildUnit(data);
            InstantiateUnit(unit, spawnLocation);            
            ObjectRegistry.AddUnit(unit, data.isEnemy);

        }

        /// <summary>
        /// Build unit from prefab and set settings from UnitData
        /// </summary>
        /// <param name="data">List of settings</param>
        void BuildUnit(UnitData data)
        {
            unit = data.prefab;
            

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
            

            //set attack settings
            attackController = unit.GetComponent<AttackController>();
            attackController.Attack = data.attack;
            attackController.AttackSpeed = data.attackSpeed;
            attackController.AttackDistance = data.attackDistance;
        }


        void InstantiateUnit(GameObject unit, Vector3 spawnLocation)
        {
            GameObject spawnedUnit = Instantiate(unit);
            spawnedUnit.transform.parent = parent.transform;
            spawnedUnit.transform.localPosition = spawnLocation;


        }

            void SetMaterial(GameObject unit, Material material)
        {
            unit.GetComponent<Renderer>().material = material;
            unit.gameObject.transform.GetChild(0).GetComponent<Renderer>().material = material;
        }

    }
}