using UnityEngine;

namespace Units
{
	[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Object/UnitData")]
	public class UnitData : ScriptableObject
	{
		[Header("Units Settings")]		
		//Fields for HealthController
		public float maxHealth;
		[Range(0, 1)]
		public float armor;
		public float gold;
		public float xp;

		[Space]
		//Fields for AttackController
		public float attack;
		public float attackSpeed;
		public float attackDistance;
		
		[Space]
		//Fields for UnitBehaviour
		public bool isEnemy;
		public TypeOfUnit typeOfUnit;
		public float speed;
		
		[Space]
		//Fields for UnitBuilder
		public float trainingTime;
		public GameObject prefab;
		public Material material;

		[Header("Level Settings")]
		public int level;
		public float costToUpdateThisLevel;

		public enum TypeOfUnit
		{
			minionWarrior,
			minionArcher,
			hero,
			enemyWarrior,
			enemyArcher,
			enemyBoss
		}

	}
}
