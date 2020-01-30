using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Units.Health
{
    public class HealthController : MonoBehaviour
    {
        private float maxHealth;
        private float currentHealth = 1;
        private float armor;
        private int goldForDeath;
        private int xpForDeath;
        [HideInInspector]
        public GameObject deadUnit;
        [HideInInspector]
        public GameObject parentForDead;
        [HideInInspector]
        public bool isEnemy;




        #region Setters and getters


        public float MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                if (value > 0)
                {
                    maxHealth = value;
                }
            }
        }

        public float Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value > 0 && value < 1)
                {
                    armor = value;
                }
            }
        }


        public float Health
        {
            get
            {
                return currentHealth;
            }
            set
            {
                if (value > 0)
                {
                    Debug.Log(value);
                    currentHealth = value;
                }
            }

        }

        public int Gold
        {
            get
            {
                return goldForDeath;
            }
            set
            {
                if (value > 0)
                {
                    goldForDeath = value;
                }
            }
        }

        public int Xp
        {
            get
            {
                return xpForDeath;
            }
            set
            {
                if (value > 0)
                {
                    xpForDeath = value;
                }
            }
        }


        #endregion


        public void TakeDamage(float damage)
        {
            if (damage <= 0)
            {
                return;
            }
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                DeadOfUnit();
            }
        }

        /// <summary>
        /// If this instance is at max health.
        /// </summary>
        public bool isAtMaxHealth
        {
            get { return Mathf.Approximately(currentHealth, maxHealth); }
        }

        protected void AddHealth(float healthIncrement)
        {
            if (healthIncrement <= 0)
            {
                return;
            }
            if (currentHealth + healthIncrement > maxHealth)
            {
                currentHealth = maxHealth;
            }
            currentHealth += healthIncrement;
        }

        public void DeadOfUnit()
        {
            ObjectRegistry.RemoveUnit(gameObject, isEnemy);
            Destroy(GetComponent<Rigidbody>());
            InstantiateDeadUnit();
            Destroy(gameObject);
        }


        public void InstantiateDeadUnit()
        {

            GameObject spawnedUnit = Instantiate(deadUnit);
            spawnedUnit.transform.parent = parentForDead.transform;
            spawnedUnit.transform.localPosition = transform.localPosition;
        }

    }
}
