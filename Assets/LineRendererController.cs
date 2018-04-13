using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private SpringJoint joint;

    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        joint = GetComponentInParent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPositions(new Vector3[] { this.gameObject.transform.parent.position, joint.connectedBody.transform.position });
    }
}
