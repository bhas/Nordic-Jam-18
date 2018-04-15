using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform Target;
    public Transform Ball;
    public float Distance;
    public float Height;
    public float LerpAmount;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var targetPos = new Vector3(Target.position.x + Distance, Target.position.y + Height, Target.position.z - Distance);

        var lerped = Vector3.Lerp(Target.position, Ball.position, LerpAmount);
        gameObject.transform.LookAt(lerped);

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 0.8f * Time.deltaTime);

	}
}
