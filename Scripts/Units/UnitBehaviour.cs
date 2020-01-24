using UnityEngine;
using System.Collections;

public class UnitBehaviour : MonoBehaviour 
{

	private bool haveTarget;
	private NavMeshAgent[] navAgents;
    public Transform target;
	
	void Start () 
	{
		haveTarget = false;
		navAgents = FindObjectsOfType(typeof(NavMeshAgent)) as NavMeshAgent[];
	}
	
	// Update is called once per frame
	void Update () 
	{
        transform.Translate(Vector3.right*Time.deltaTime*2);
	}
	
	private void UpdateTargets ( Vector3 targetPosition )
    {
      foreach(NavMeshAgent agent in navAgents) 
      {
        agent.destination = targetPosition;
      }
    }
}
