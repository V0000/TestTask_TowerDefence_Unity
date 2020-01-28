using UnityEngine;
using System.Collections;

namespace Units
{
	[RequireComponent(typeof(HealthController), typeof(AttackController)), typeof(NavMeshAgent))]
	public class UnitBehaviour : MonoBehaviour 
	{
		[HideInInspector]
		public bool isEnemy;
		public Transform fountain;
		private GameObject target;
		private NavMeshAgent agent;
		private AttackController attackController;
		private HealthController healthController;
		private bool attackRunning = false;
		
		
		
		void Start () 
		{
			agent = GetComponent<NavMeshAgent>();
			attackController = GetComponent<AttackController>();
			healthController = GetComponent<HealthController>();
		}
		

		void Update () 
		{
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!будет грузить пиздос, переделать
			UpdateTargets();
			agent.destination = target.transform.position;
			AttackSwicher()
			CheckDeath();
		}

		void OnDrawGizmos()
		{
			Debug.DrawRay(transform.position, target.transform.position);
		}	

		void CheckDeath()
		{
			if(IsDead)
			{
				ObjectRegistry.RemoveUnit(unit, isEnemy);
			}
		}			
		
		void AttackSwicher()
		{
			if(Vector3.Distance(target.transform.position, objectTransform.position)<attackController.attackDistance)
			{
				if(!attackRunning)
				{
					attackRunning = true;
					StartAttack(target);
				}
			}
			else
			{
				if(attackRunning)
				{
					attackRunning = false;
					StopAttack();
				}
			}
		}
		

		private void UpdateTargets ()
		{
			if (ObjectRegistry.TargetIsExist(isEnemy))
			{
				target = ObjectRegistry.fountain;            
			}
			else
			{
				target = ObjectRegistry.GetNearestTarget(transform, isEnemy);
			}
		}
	}
}
