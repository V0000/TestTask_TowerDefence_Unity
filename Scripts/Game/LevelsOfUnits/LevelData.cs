using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Scriptable Object/LevelData")] 
public class LevelData : ScriptableObject {

	public TypeOfUnit typeOfUnit;
	public int maxHealth;
	[Range(0,1)]
	public float armor;
	public float speed;
	public float attackPower;	
	public float attackDistance;
    public float goldForDeath;
    public float xpForDeath;
	
	public GameObject prefab;
	
	public enum TypeOfUnit
	{
		minionWarrior,
		minionArcher,
		hero
		enemyWarrior,
		enemyArcher,
		enemyBoss
	}
	
}
