﻿using System.Collections;
using Units.Health;
using UnityEngine;

namespace Units.Attack
{
    /// <summary>
    /// Class implement attack of any unit
    /// </summary>
    public class AttackController : MonoBehaviour
    {
        [HideInInspector]
        public float attack;
        private float attackSpeed;
        [HideInInspector]
        public float attackDistance = 0;
        private bool attackRunning = false;
        //healthController of prey
        private HealthController healthControllerTarget;
        private UnitBehaviour unitBehaviour;
        private float timeForStartAttack = 1f;
        [HideInInspector]
        public GameObject target;

        void Start()
        {
            unitBehaviour = GetComponent<UnitBehaviour>();
            StartCoroutine(AttackSwicher());
        }

        #region Properties


        public float Attack
        {
            get
            {
                return attack;
            }
            set
            {
                if (value > 0)
                {

                    attack = value;
                }
            }
        }

        public float AttackSpeed
        {
            get
            {
                return attackSpeed;
            }
            set
            {
                if (value > 0)
                {
                    attackSpeed = value;
                }
            }
        }

        public float AttackDistance
        {
            get
            {

                return attackDistance;
            }
            set
            {
                if (value > 0)
                {

                    attackDistance = value;
                }
            }
        }

        #endregion

        private IEnumerator AttackPerTime()
        {
            Debug.Log(healthControllerTarget);
            if (healthControllerTarget != null)
            {
                
                healthControllerTarget.TakeDamage(attack);
            }
            else
            {
                //unitBehaviour.TargetIsDead();
            }
            
            yield return new WaitForSeconds(attackSpeed);
            StartCoroutine(AttackPerTime());
        }

        /// <summary>
        /// Start and stop attack according to distance from target
        /// </summary>
        public IEnumerator AttackSwicher()
        {


            if (target != null && Vector3.Distance(target.transform.position, transform.position) < attackDistance)
            {

                if (!attackRunning)
                {

                    attackRunning = true;
                    healthControllerTarget = target.GetComponent<HealthController>();
                    StartCoroutine(AttackPerTime());
                }
            }
            else
            {
                if (attackRunning)
                {
                    attackRunning = false;
                    StopCoroutine(AttackPerTime());
                }
            }
            yield return new WaitForSeconds(timeForStartAttack);
            StartCoroutine(AttackSwicher());
        }

    }
}
