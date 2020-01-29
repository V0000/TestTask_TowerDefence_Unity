using System.Collections;
using Units.Health;
using UnityEngine;

namespace Units.Attack
{
    public class AttackController : MonoBehaviour
    {
        private float attack;
        private float attackSpeed;
        private float attackDistance;
		private bool attackRunning = false;
        private HealthController healthController;
		

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

        private IEnumerator AttackPerTime(HealthController healthController)
        {
            while (true)
            {
                healthController.TakeDamage(attack);
                yield return new WaitForSeconds(attackSpeed);
            }
        }
		
        void AttackSwicher(GameObject target)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < attackController.AttackDistance)
            {
                if (!attackRunning)
                {
                    attackRunning = true;
					healthController = target.GetComponent<HealthController>();
					StartCoroutine(AttackPerTime(healthController));
                }
            }
            else
            {
                if (attackRunning)
                {
                    attackRunning = false;
                    StopCoroutine(AttackPerTime(healthController));
                }
            }
        }		

    }
}
