using UnityEngine;
using System.Collections;
using Units.Data;

namespace Buildings
{
	/// <summary>
    /// Abstract class for all buildings that can build units
    /// </summary>
	[RequireComponent(typeof(UnitBuilder))]
    public abstract class SpawnController : MonoBehaviour
    
		//settings for build unit
        protected UnitData selectedUnit;
		private UnitBuilder builder;
        protected Vector3 spawnLocation;
        protected float spawnTime;
        

        protected virtual void Start()
        {
            builder = GetComponent<UnitBuilder>();
            spawnLocation = transform.position + Vector3.back;
            spawnLocation.y = 2.5f;

        }

		/// <summary>
		/// Build unit and set in coordinates
		/// </summary>
        protected void CreateUnit()
        {
            builder.NewUnit(selectedUnit, spawnLocation);
        }
		/// <summary>
		/// Spawn unit every time seconds
		/// </summary>
        protected virtual IEnumerator SpawnPerTime(float time)
        {
            while (true)
            {

                yield return new WaitForSeconds(time);
                if (selectedUnit != null)
                {

                    CreateUnit();
                }
            }
        }
    }
}