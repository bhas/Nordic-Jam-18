using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorTools {

    [MenuItem("Tools/Set correct links and align point")]
    private static void NewMenuOption()
    {
        var alignerPoint = GameObject.FindGameObjectWithTag("AlignerPoint");
        var anchorPoint = GameObject.FindGameObjectWithTag("AnchorPoint");
        var wreckingBall = GameObject.FindGameObjectWithTag("WreckingBall");

        var spring = wreckingBall.GetComponent<SpringJoint>();
        if (spring.connectedBody == null)
            spring.connectedBody = anchorPoint.GetComponent<Rigidbody>();

        var anchorAligner = anchorPoint.GetComponent<AnchorPointAligner>();
        if (anchorAligner.AnchorLocator == null)
            anchorAligner.AnchorLocator = alignerPoint.transform;

        anchorAligner.transform.position = anchorAligner.AnchorLocator.position;
        anchorAligner.transform.rotation = Quaternion.Euler(new Vector3(0, anchorAligner.AnchorLocator.rotation.eulerAngles.y, 0));
    }
}
