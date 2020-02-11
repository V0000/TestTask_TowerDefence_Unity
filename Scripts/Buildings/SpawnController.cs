using UnityEngine;
using System.Collections;
using Units.Data;

namespace Buildings
{
	[RequireComponent(typeof(UnitBuilder))]
    public abstract class SpawnController : MonoBehaviour
    {
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

        protected void CreateUnit()
        {
            builder.NewUnit(selectedUnit, spawnLocation);
        }

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