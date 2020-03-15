using System.Collections;
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
        private float timer;
        [HideInInspector]
        public float attackDistance = 0;

        //healthController of prey
        public HealthController healthControllerTarget;


        [HideInInspector]
        public GameObject target;

        void Update()
        {
            if (timer > attackSpeed)
            {
                AttackTarget();
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }

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

        private void Hit()
        {

            
            if (healthControllerTarget != null)
            {

                healthControllerTarget.TakeDamage(attack);
            }

        }

        /// <summary>
        /// Start and stop attack according to distance from target
        /// </summary>
        public void AttackTarget()
        {


            if (target != null && Vector3.Distance(target.transform.position, transform.position) < attackDistance)
            {
                {
                    Hit();

                }

            }

        }
    }
}