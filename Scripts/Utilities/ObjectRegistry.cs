using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// In this class are registered all units available for interaction.
    /// Class using for simplification the seath for objects.
    /// </summary>
    public static class ObjectRegistry

    {
        // Lists with all units
        private static List<GameObject> enemies = new List<GameObject>();
        private static List<GameObject> minions = new List<GameObject>();

        //Main Camera
        public static GameObject mainCamera;

        //Healer
        public static GameObject fountain;

        //Main target of enemies
        public static GameObject couch;
		
		//Main resourses of player
		public static int gold = 0;
		public static int xp = 0;

        //Count of units
        public static int minionsCount = 0;
        public static int enemyCount = 0;
        public static int allUnitsCount = 0;
        /// <summary>
        /// Find in lists of units nearest object
        /// </summary>
        /// <param name="damageValue">Transform component of object</param>
        /// <param name="damagePoint">Are object is enemy?</param>
        public static GameObject GetNearestTarget(Transform objectTransform, bool youIsEnemy)
        {
            GameObject nearestObject = null;
            float nearestDistance = Mathf.Infinity;            
            float distance;
            List<GameObject> units = youIsEnemy ? minions : enemies;
            foreach (GameObject target in units)
            {
                distance = Vector3.Distance(target.transform.position, objectTransform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestObject = target;
                }
                
            }
            
            return nearestObject;
        }

        public static bool TargetIsExist(bool youIsEnemy)
        {            
            if (youIsEnemy)
            {
                return minionsCount != 0;
            }
            return enemyCount != 0;
        }
        public static void AddUnit(GameObject unit, bool youIsEnemy)
        {
            if (youIsEnemy)
            {
                enemies.Add(unit);
            }
            else
            {
                minions.Add(unit);
            }
            UpdateCountOfUnits();
        }
        public static void RemoveUnit(GameObject unit, bool youIsEnemy)
        {
            if (youIsEnemy)
            {
                enemies.Remove(unit);
            }
            else
            {
                minions.Remove(unit);
            }
            //Debug.Log(String.Format("{0} enemies, {1} minions",enemies.Count(), minions.Count()));
        }

        public static void UpdateCountOfUnits()
        {
            minionsCount = minions.Count();
            enemyCount = enemies.Count();
        }

    }
}