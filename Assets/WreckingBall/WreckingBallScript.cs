using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallScript : MonoBehaviour
{
    public Transform Target;
    public Rigidbody Body;


    public Transform HingeTarget;
    private float MaxDistance = 5;
    private Vector3 Velocity;
    public float Acceleration;
    public float GravityPower;

    private void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //var distanceFromHinge = Vector3.Distance(this.gameObject.transform.position, HingeTarget.position);
        //Vector3 velocity = Vector3.down * GravityPower;
        ////if (Mathf.Abs(distanceFromHinge - MaxDistance) < 0.005f)
        //    //return;

        //if (distanceFromHinge > MaxDistance)
        //{
        //    velocity += (HingeTarget.position - transform.position) * 0.2f;
        //}
        //Velocity += velocity * Acceleration;
        //Velocity *= 0.99f;

        //this.gameObject.transform.position += Velocity;

        var direction = Target.position - gameObject.transform.position;
        var distance = Vector3.Distance(Target.position, gameObject.transform.position);

        var forceCentri = Target.forward * Body.velocity.magnitude * 0.5f;
        var moveTowardsCenter = direction * 0.75f;

        Body.AddForce(moveTowardsCenter, ForceMode.VelocityChange);
        //Body.AddForce(forceCentri);
        //Body.AddForce(Target.forward * Body.velocity.magnitude, );

        //var direction2 = HingeTarget.position - gameObject.transform.position;
        //Body.AddForce(direction2 * 0.75f, ForceMode.VelocityChange);
    }
}
