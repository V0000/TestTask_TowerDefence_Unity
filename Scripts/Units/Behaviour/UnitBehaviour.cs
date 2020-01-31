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
		private float timeForFingTarget = 1f;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            attackController = GetComponent<AttackController>();
            healthController = GetComponent<HealthController>();
			StartCoroutine(FindTargetPerTime(timeForFingTarget)); 
        }

        void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, target.transform.position);
        }		
		
		private IEnumerator FindTargetPerTime(float time)
        {

                yield return StartCoroutine(UpdateTargets());
				agent.destination = target.transform.position;
                yield return new WaitForSeconds(time);
				StartCoroutine(FindTargetPerTime(timeForFingTarget));
            
        } 

        private IEnumerator UpdateTargets()
        {
            if (ObjectRegistry.TargetIsExist(isEnemy))
            {
                target = ObjectRegistry.GetNearestTarget(transform, isEnemy);
				attackController.target = target;
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
					attackController.target = null;
				}	
            }
        }       
    }
}
