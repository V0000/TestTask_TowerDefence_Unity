using UnityEngine;
using System.Collections;
using Utilities;

namespace Buildings
{
    public class FountainController : MonoBehaviour
    {
		private Collider[] hitColliders;
		private Vector3 center; 
		public float healRadius = 5f;
		public float healFrequency = 1f;
		public float healNumber = 5f;

        void Start()
        {
            ObjectRegistry.fountain = gameObject;
			center = gameObject.transform.position;			
			StartCoroutine(HealAllInRadius()); 
        }

		
		private IEnumerator HealAllInRadius()
        {
			hitColliders = Physics.OverlapSphere(center, healRadius);
			f
			yield return new WaitForSeconds(healFrequency);
			StartCoroutine(HealAllInRadius()); 
        }
    }
}