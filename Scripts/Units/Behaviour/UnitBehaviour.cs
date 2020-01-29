using UnityEngine;
using System.Collections;
using Units.Health;
using Units.Attack;
using Utilities;

namespace Units
{
    [RequireComponent(typeof(HealthController), typeof(AttackController), typeof(NavMeshAgent))]
    public class UnitBehaviour : MonoBehaviour
    {
        [HideInInspector]
        public bool isEnemy;        
        private GameObject target;
        private NavMeshAgent agent;
        private AttackController attackController;
        private HealthController healthController;        
		private float timeForFingTarget = 2f;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            attackController = GetComponent<AttackController>();
            healthController = GetComponent<HealthController>();
			StartCoroutine(FindTargetPerTime(timeForFingTarget)); 

        }

        void Update()
        {
            attackController.AttackSwicher(target);
            CheckDeath();
        }
		
		void OnDestroy()
        {
			//Reward for killing enemy
            if (isEnemy)
			{
				ObjectRegistry.gold += healthController.Gold;
				ObjectRegistry.xp += healthController.Xp;
			}
        }

        void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, target.transform.position);
        }

        private void UpdateTargets()
        {
            if (ObjectRegistry.TargetIsExist(isEnemy))
            {
                target = ObjectRegistry.GetNearestTarget(transform, isEnemy);			
            }
            else
            {
                if(isEnemy)
				{
					target = ObjectRegistry.couch;
				}
				else
				{
					target = ObjectRegistry.fountain;
				}	
            }
        }
		
		private IEnumerator FindTargetPerTime(float time)
        {
            while (true)
            {
                UpdateTargets();
				agent.destination = target.transform.position;
                yield return new WaitForSeconds(time);
            }
        }

        public void CheckDeath()
        {
            if (healthController.IsDead)
            {
                ObjectRegistry.RemoveUnit(gameObject, isEnemy);
                Destroy(GetComponent<Rigidbody>());
                healthController.InstantiateDeadUnit();
                Destroy(gameObject);
            }
        }
    }
}
