using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour {

    public ParticleSystem destructionParticles;
    public int Countdown;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        GoMad();
    }

    private void GoMad()
    {
        destructionParticles.Play();
        Destroy(this.gameObject);
    }
}
