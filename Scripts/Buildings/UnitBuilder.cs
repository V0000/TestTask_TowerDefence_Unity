using System.Collections;
using UnityEngine;

namespace Buildings
{
	public class UnitBuilder : MonoBehaviour
	{
		public GameObject parent;    
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
			healthController.Armor = data.armor;
			healthController.Gold = data.gold;
			healthController.Hp = data.hp;
			
			//set attack settings
			attackController = unit.GetComponent<AttackController>();
			attackController.Attack = data.attack;
			attackController.AttackSpeed = data.attackSpeed;
			attackController.AttackDistance = data.attackDistance;
			
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
		
	}
}