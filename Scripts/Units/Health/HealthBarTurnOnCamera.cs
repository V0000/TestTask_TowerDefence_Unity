using UnityEngine;
using System.Collections;
using Utilities;

public class HealthBarTurnOnCamera : MonoBehaviour
{
	void Update () 
	{
		Vector3 dir = ObjectRegistry.mainCamera.transform.position - transform.position;
		dir.y = 0;
		transform.rotation = Quaternion.LookRotation(dir);
	}
}
