using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class WreckingBallScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (!Application.isEditor || Application.isPlaying)
            return;

        var spring = GetComponent<SpringJoint>();
        if (spring.connectedBody == null)
            spring.connectedBody = GameObject.FindGameObjectWithTag("AnchorPoint").GetComponent<Rigidbody>();
    }
}
