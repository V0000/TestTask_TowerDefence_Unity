using UnityEngine;
using System.Collections;

namespace Units.Data
{
    [CreateAssetMenu(fileName = "TypesOfUnits", menuName = "Scriptable Object/TypesOfUnits")]
    public class TypesOfUnits : ScriptableObject
    {
        public UnitData[] minionWarriors;
        public UnitData[] minionArchers;
        public UnitData[] hero;
        public UnitData[] enemyWarriors;
        public UnitData[] enemyArchers;
        public UnitData[] boss;

    }
}