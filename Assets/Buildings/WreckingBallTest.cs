using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallTest : MonoBehaviour
{
	public float velocity;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = Vector3.forward * velocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
