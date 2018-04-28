using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPiece : MonoBehaviour
{
	public float breakingPoint = 5;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision coll)
	{
		// ignore tiny collisions
		var collisionPower = coll.impulse.magnitude;
		if (collisionPower < breakingPoint)
			return;


		// activate physics for piece
		print(collisionPower);
		var rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.None;
	}
}
