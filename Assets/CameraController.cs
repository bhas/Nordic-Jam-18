using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform Target;
    public float Distance;
    public float Height;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var targetPos = new Vector3(Target.position.x + Distance, Target.position.y + Height, Target.position.z - Distance);
        gameObject.transform.LookAt(Target.position);

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 0.2f * Time.deltaTime);

	}
}
