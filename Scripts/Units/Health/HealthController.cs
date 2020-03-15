using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Units.Health
{
    public class HealthController : MonoBehaviour
    {
        public float maxHealth;
        public float currentHealth = 1;
        public float armor;
        //Reward for killing this enemy
        private int goldForDeath;
        private int xpForDeath;
        [HideInInspector]
        public GameObject deadUnit;

        public GameObject parentForDead;
        public Image healthBar;
        private UnitBehaviour unitBehaviour;

        //[HideInInspector]
        public bool isEnemy;
        public bool isDead;

        public delegate void deadCallback();
        public deadCallback OnDead = delegate { };



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

        void Start()
        {
            isDead = false;
            unitBehaviour = GetComponent<UnitBehaviour>();

        }

        void Update()
        {
            //healthBar.fillAmount = Mathf.InverseLerp(0, maxHealth, currentHealth);

        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
            {
                return;
            }
            currentHealth -= damage;
            healthBar.fillAmount = Mathf.InverseLerp(0, maxHealth, currentHealth);
            if (currentHealth <= 0)
            {
                //nobody can't be dead twice
                if (!isDead) DeadOfUnit();
            }
        }

        /// <summary>
        /// If this instance is at max health.
        /// </summary>
        public bool isAtMaxHealth
        {
            get { return Mathf.Approximately(currentHealth, maxHealth); }
        }

        public void AddHealth(float healthIncrement)
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
            healthBar.fillAmount = Mathf.InverseLerp(0, maxHealth, currentHealth);
        }

        public void DeadOfUnit()
        {

            //Reward for killing enemy
            if (isEnemy)
            {
                ObjectRegistry.gold += goldForDeath;
                ObjectRegistry.xp += xpForDeath;
            }
            isDead = true;
            OnDead();
            unitBehaviour.UnitIsDead();
            ObjectRegistry.RemoveUnit(gameObject, isEnemy);
            Destroy(GetComponent<Rigidbody>());
            //Destroy(GetComponent<UnitBehaviour>());
            Destroy(GetComponent<MeshRenderer>());
            //Deactivate all childs
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false); 
            }

            //InstantiateDeadUnit();
            Destroy(gameObject, 6);

        }


        public void InstantiateDeadUnit()
        {

            GameObject spawnedUnit = Instantiate(deadUnit);
            spawnedUnit.transform.parent = parentForDead.transform;
            spawnedUnit.transform.localPosition = transform.localPosition;
        }

    }
}
