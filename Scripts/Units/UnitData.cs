using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Object/UnitData")]
public class UnitData : ScriptableObject
{
    [Header("Units Settings")]
	public bool isEnemy;
    public TypeOfUnit typeOfUnit;
    public int maxHealth;
    [Range(0, 1)]
    public float armor;
    public float speed;
    public float attack;
    public float attackSpeed;
    public float attackDistance;
    public float trainingTime;
    public float gold;
    public float XP;
    public GameObject prefab;
    public Material material;

    [Header("Level Settings")]
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
