using UnityEngine;
using System.Collections;
using Utilities;

public class AlwaysTurnOnCamera : MonoBehaviour {


	private float turnSpeed = 1;
	void Update () 
	{
		Vector3 dir = ObjectRegistry.mainCamera.transform.position - transform.position;
		dir.y = 0;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime, Space.World);
	}
}
