using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderController : MonoBehaviour
{
    public Transform Target;
    public Rigidbody Body;

    private void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {

        var direction = Target.position - gameObject.transform.position;
        Body.AddForce(direction*0.5f, ForceMode.VelocityChange);
    }
}
