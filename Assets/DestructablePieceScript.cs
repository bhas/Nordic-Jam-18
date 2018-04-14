using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DestructablePieceScript : MonoBehaviour {

    private float Threshold = 1.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > Threshold)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.velocity.magnitude > Threshold)
        {
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
