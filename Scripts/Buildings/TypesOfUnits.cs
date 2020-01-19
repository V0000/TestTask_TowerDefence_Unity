using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "TypesOfUnits", menuName = "Scriptable Object/TypesOfUnits")]
public class 
    TypesOfUnits : ScriptableObject
{

    public LevelData[] minionWarriors;
    public LevelData[] minionArchers;
    public LevelData[] hero;
    public LevelData[] enemyWarriors;
    public LevelData[] enemyArchers;
    public LevelData[] boss;


}
