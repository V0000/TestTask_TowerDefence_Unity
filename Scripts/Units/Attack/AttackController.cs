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
        private HealthController healthControllerTarget;
		private float timeForStartAttack = 1f;
		[HideInInspector]
		public GameObject target;
		
		void Start()
        {
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
                healthControllerTarget.TakeDamage(attack);
                yield return new WaitForSeconds(attackSpeed);
				StartCoroutine(AttackPerTime());            
        }
		
        public IEnumerator AttackSwicher()
        {
			
				if (target == null)
				{
					yield return null;
				}
				if (Vector3.Distance(target.transform.position, transform.position) < AttackDistance)
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
