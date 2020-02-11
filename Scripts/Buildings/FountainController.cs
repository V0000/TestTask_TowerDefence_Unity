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

		
		private IEnumerator HealAllInRadius()
        {
			hitColliders = Physics.OverlapSphere(center, healRadius);
			foreach (Collider unitCollider in hitColliders)
			{
				unitCollider.gameObject.GetComponent<HealthController>().AddHealth(healValue);
			}
			yield return new WaitForSeconds(healFrequency);
			StartCoroutine(HealAllInRadius()); 
        }
    }
}