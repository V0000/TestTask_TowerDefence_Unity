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

        //Healer
        public static GameObject fountain;

        //Main target of enemies
        public static GameObject couch;

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
            Debug.Log(nearestObject);
            return nearestObject;
        }

        public static bool TargetIsExist(bool youIsEnemy)
        {
            List<GameObject> units = youIsEnemy ? minions : enemies;
            if (units.Any())
            {
                return true;
            }
            return false;
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
        }

    }
}