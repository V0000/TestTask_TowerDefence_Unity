using UnityEngine;
using System.Collections;

public class UnitBehaviour : MonoBehaviour 
{
    [HideInInspector]
    public bool isEnemy;
    public Transform fountain;
    private GameObject target;
    private NavMeshAgent agent;
    
	
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
    }
	

	void Update () 
	{
        UpdateTargets();
        agent.destination = target.transform.position;
    }

    void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, target.transform.position);
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
