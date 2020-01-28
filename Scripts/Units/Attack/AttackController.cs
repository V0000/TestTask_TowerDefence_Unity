using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units.Attack
{
	public class AttackController : MonoBehaviour
	{
		private float attack;
		private float attackSpeed;
		private float attackDistance;
		private HealthController healthController;
		
#region Setters and getters


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
		

		public void StartAttack(GameObject target)
		{			
			healthController = target.GetComponent<HealthController>();
			StartCoroutine(AttackPerTime());
		}	

		public void StopAttack()
		{
			StopCoroutine(AttackPerTime());
		}	
		
		
		private IEnumerator AttackPerTime(HealthController healthController)
		{
			while (true)        
			{	
				healthController.TakeDamage(attack);
				yield return new WaitForSeconds(attackSpeed);

			}
		}
		
	}
}
