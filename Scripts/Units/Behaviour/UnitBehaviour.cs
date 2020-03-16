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
		private bool selected;
        public GameObject target;
        private NavMeshAgent agent;
        private AttackController attackController;
        private HealthController healthControllerTarget;
        private float timeForFingTarget = 2f;
        private float timer;


        void Start()
        {
            ObjectRegistry.AddUnit(gameObject, isEnemy);
            agent = GetComponent<NavMeshAgent>();
            attackController = GetComponent<AttackController>();
            
        }

        void Update()
        {
            if (timer > timeForFingTarget)
            {
                FindTargetPerTime();
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        void OnDrawGizmos()
        {
            if(target!=null)
            {
               Debug.DrawRay(transform.position, target.transform.position - transform.position, isEnemy? Color.red: Color.yellow);
            }
            
        }		
		
		private void FindTargetPerTime()
        {
                UpdateTargets();
                agent.destination = target != null ? target.transform.position : transform.position;               			
            
        } 

        private void UpdateTargets()
        {
            if (ObjectRegistry.TargetIsExist(isEnemy))
            {
                target = ObjectRegistry.GetNearestTarget(transform, isEnemy);                
                attackController.target = target;
                if (target != null) healthControllerTarget = target.GetComponent<HealthController>();
                attackController.healthControllerTarget = healthControllerTarget;
                healthControllerTarget.OnDead += TargetIsDead;
    }
            else
            {
                if(isEnemy)
				{
					target = ObjectRegistry.couch;
                    attackController.target = target;
                }
				else
				{
					target = ObjectRegistry.fountain;
					attackController.target = null;
				}	
            }
            //Debug.Log(gameObject.name + " isEnemy " + isEnemy + " attack " + target.name);
            
        }   
        
        public void TargetIsDead()
        {
            target = ObjectRegistry.fountain;
            UpdateTargets();
        }
        public void UnitIsDead()
        {
            healthControllerTarget.OnDead -= TargetIsDead;
        }
    }
}
