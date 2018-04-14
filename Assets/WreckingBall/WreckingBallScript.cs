using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallScript : MonoBehaviour
{
    public Transform Target;
    public Transform HingeTarget;
    public Rigidbody Body;

    private void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var direction = Target.position - gameObject.transform.position;
        var distance = Vector3.Distance(Target.position, gameObject.transform.position);
        Body.AddForce(direction * 0.75f, ForceMode.VelocityChange);

        var direction2 = HingeTarget.position - gameObject.transform.position;
        //Body.AddForce(direction2 * 0.75f, ForceMode.VelocityChange);
    }
}
