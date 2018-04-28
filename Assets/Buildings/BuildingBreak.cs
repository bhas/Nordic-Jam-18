using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBreak : MonoBehaviour
{

	public GameObject brokenPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other)
	{
		//if (!other.CompareTag("WreckingBall"))
		//	return;

		var broken = GameObject.Instantiate(brokenPrefab, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
