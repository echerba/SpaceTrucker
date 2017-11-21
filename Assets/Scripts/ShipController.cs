using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	private Rigidbody shipRigidbody;

	private static bool moving = false;
	private static Transform destination;

	public float RotationSpeed = .1f;

	public float ShipAcceleration = 2f;
	
	public float ShipMaxSpeed = 10f;

	// Use this for initialization
	void Start () {
		shipRigidbody = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {

		if (!moving)
			return;

		Vector3 relativePos = destination.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        
		if (Quaternion.Angle(transform.rotation, rotation) >= 0.1f)
		{
			//Debug.Log("Rotation: " + Quaternion.Angle(transform.rotation, rotation));
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
		}
		else if (relativePos.x >= 5 || 
				 relativePos.y >= 5 || 
				 relativePos.z >= 5)
		{
			//Debug.Log("moving, velocity: " + shipRigidbody.velocity.magnitude);
			
			if (shipRigidbody.velocity.magnitude < ShipMaxSpeed)
			{
				Vector3 force = transform.forward * ShipAcceleration;
				shipRigidbody.AddForce(force, ForceMode.Force);
			}

			this.transform.position = shipRigidbody.transform.position;
		}
		else
		{
			//Debug.Log("stopped");
			shipRigidbody.velocity = Vector3.zero;
		}
	}

	public static void SetDestination(Transform targetTransform)
	{
		destination = targetTransform;
		moving = true;
	}
}
