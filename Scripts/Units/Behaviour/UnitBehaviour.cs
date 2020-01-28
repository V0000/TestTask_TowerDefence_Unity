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
        public Transform fountain;
        private GameObject target;
        private NavMeshAgent agent;
        private AttackController attackController;
        private HealthController healthController;
        private bool attackRunning = false;



        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            attackController = GetComponent<AttackController>();
            healthController = GetComponent<HealthController>();
        }


        void Update()
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!будет грузить пиздос, переделать
            UpdateTargets();
            agent.destination = target.transform.position;
            AttackSwicher();
            CheckDeath();
        }

        void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, target.transform.position);
        }

        void CheckDeath()
        {
            if (healthController.IsDead)
            {
                ObjectRegistry.RemoveUnit(gameObject, isEnemy);
            }
        }

        void AttackSwicher()
        {
            if (Vector3.Distance(target.transform.position, transform.position) < attackController.AttackDistance)
            {
                if (!attackRunning)
                {
                    attackRunning = true;
                    attackController.StartAttack(target);
                }
            }
            else
            {
                if (attackRunning)
                {
                    attackRunning = false;
                    attackController.StopAttack();
                }
            }
        }


        private void UpdateTargets()
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
