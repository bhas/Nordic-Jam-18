using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private HingeJoint joint;
    public List<Transform> HingePoints;

    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        joint = GetComponentInParent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPositions(HingePoints.Select(t => t.position).ToArray());
    }
}
