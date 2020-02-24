using UnityEngine;
using System.Collections;
using Utilities;
using Units.Health;
using System;

namespace Buildings
{	
	/// <summary>
    /// Class for healind buildings
    /// </summary>
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
		protected override void Start()
		{            
			center = transform.position;			
			//StartCoroutine(HealAllInRadius()); 
        }

		/// <summary>
		/// Find all minions in radius and heal them
		/// </summary>		
		private IEnumerator HealAllInRadius()
        {
			hitColliders = Physics.OverlapSphere(center, healRadius);
			if (hitColliders.Length != 0)
			{
				foreach (Collider unitCollider in hitColliders)
				{
					try
					{
						unitCollider.gameObject.GetComponent<HealthController>().AddHealth(healValue);
					}
					catch
					{
						Debug.LogWarning(String.Format("Object {0} haven't HealthController", unitCollider.gameObject));
					}
					
				}
			}
			yield return new WaitForSeconds(healFrequency);
			StartCoroutine(HealAllInRadius()); 
        }
    }
}