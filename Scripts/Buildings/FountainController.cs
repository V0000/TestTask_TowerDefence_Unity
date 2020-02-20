using UnityEngine;
using System.Collections;
using Utilities;
using Units.Health;

namespace Buildings
{
    public class FountainController : SpawnController
    {
		private Collider[] hitColliders;
		private Vector3 center; 
		public float healRadius = 5f;
		public float healFrequency = 1f;
		public float healValue = 5f;

		void Awake()
		{
			ObjectRegistry.fountain = gameObject;
		}
		void Start()
        {            
			center = transform.position;			
			StartCoroutine(HealAllInRadius()); 
        }

		/// <summary>
		/// Find all minions in radius and heal they
		/// </summary>		
		private IEnumerator HealAllInRadius()
        {
			hitColliders = Physics.OverlapSphere(center, healRadius);
			if (hitColliders.Length != 0)
			{
				foreach (Collider unitCollider in hitColliders)
				{
					unitCollider.gameObject.GetComponent<HealthController>().AddHealth(healValue);
				}
			}
			yield return new WaitForSeconds(healFrequency);
			StartCoroutine(HealAllInRadius()); 
        }
    }
}