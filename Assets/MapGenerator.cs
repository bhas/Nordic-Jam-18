using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int MapWidth;
    public int MapDepth;

    public List<GameObject> RoadPieces;

    public int Steps;

    // Use this for initialization
    void Start()
    {
        var currentPosition = new Vector3();
        var currentRotation = 0f;
        for (int i = 0; i < Steps; i++)
        {
            var currentRoadPiece = RoadPieces[UnityEngine.Random.Range(0, RoadPieces.Count - 1)];
            var go = Instantiate(currentRoadPiece);
            go.transform.position = currentPosition;
            RoadPiece rp = go.GetComponent<RoadPiece>();
            go.transform.Rotate(new Vector3(0,currentRotation,0));

            var vector = Quaternion.Euler(0, currentRotation, 0) * (new Vector3(rp.Direction.x, 0, rp.Direction.y) * 4);
            currentPosition += vector;
            currentRotation += rp.Rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
