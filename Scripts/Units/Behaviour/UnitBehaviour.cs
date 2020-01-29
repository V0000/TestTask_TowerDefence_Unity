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
			StartCoroutine(FindTargetPerTime(timeForFingTarget)));
			
        }

        void Update()
        {
            attackController.AttackSwicher(target);
            healthController.CheckDeath();
        }
		
		void OnDestroy()
        {
			//Reward for killing enemy
            if (isEnemy)
			{
				ObjectRegistry.gold += healthController.goldForDeath;
				ObjectRegistry.xp += healthController.xpForDeath;
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
    }
}
