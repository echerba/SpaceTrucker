using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	private Rigidbody shipRigidbody;

	public float RotationSpeed = .1f;

	// Use this for initialization
	void Start () {
		shipRigidbody = GetComponentInChildren<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject target = GameObject.FindGameObjectWithTag("Destination");

		Vector3 relativePos = target.transform.position - transform.position;
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
			Debug.Log("moving, velocity: " + shipRigidbody.velocity.magnitude);
			
			if (shipRigidbody.velocity.magnitude < 1f)
			{
				Vector3 force = transform.forward * .01f;
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
}
