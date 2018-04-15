using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DestructablePieceScript : MonoBehaviour
{
    private float Threshold = 1.5f;
    private int Time = 400;
    private bool Destroyed = false;
    public bool ShouldBeDestroyed = false;

    void Update()
    {
        if (Destroyed)
        {
            Time -= 1;
            if (Time <= 100)
            {
                GetComponent<BoxCollider>().enabled = false;
            }
            if (Time <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > Threshold)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (!Destroyed)
            {
                GameController.Instance.Trigger();
                GameController.Instance.Score += ShouldBeDestroyed ? 1 : -1;
            }
            Destroyed = true;

            
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
