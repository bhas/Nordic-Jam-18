using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Texture")]
    public Texture2D Level;

    [Header("Pieces")]
    public GameObject Straight;
    public GameObject Turn;
    public GameObject CrossSection;
    public GameObject TJunction;

    [Header("Container")]
    public GameObject MapContainer;

    // Use this for initialization
    void Start()
    {
        for (int x = 0; x < Level.width; x++)
        {
            for (int y = 0; y < Level.height; y++)
            {
                var road = ReadPixel(x, y);
                if (road)
                {
                    PlaceRoadPiece(x, y);
                }
            }
        }

        MapContainer.transform.position = new Vector3(-Level.width*4/2, 0, -Level.height * 4 / 2);
    }

    private bool ReadPixel(int x, int y)
    {
        var color = Level.GetPixel(x, y);
        return (int)color.r == 0;
    }

    private void PlaceRoadPiece(int x, int y)
    {
        var roadLeft = ReadPixel(x - 1, y);
        var roadAbove = ReadPixel(x, y + 1);
        var roadRight = ReadPixel(x + 1, y);
        var roadBelow = ReadPixel(x, y - 1);

        GameObject roadPiece;
        // Four-way intersection
        if (roadLeft && roadRight && roadAbove && roadBelow)
        {
            roadPiece = Instantiate(CrossSection);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
        }
        // Three-way intersection
        else if (roadLeft && roadRight && roadBelow)
        {
            roadPiece = Instantiate(TJunction);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
        }
        else if (roadLeft && roadAbove && roadBelow)
        {
            roadPiece = Instantiate(TJunction);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
            roadPiece.transform.Rotate(new Vector3(0, 90, 0));
        }
        else if (roadLeft && roadRight && roadAbove)
        {
            roadPiece = Instantiate(TJunction);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
            roadPiece.transform.Rotate(new Vector3(0, 180, 0));
        }
        else if (roadRight && roadAbove && roadBelow)
        {
            roadPiece = Instantiate(TJunction);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
            roadPiece.transform.Rotate(new Vector3(0, 270, 0));
        }
        // Straight roads
        else if (roadAbove && roadBelow)
        {
            roadPiece = Instantiate(Straight);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
        }
        else if (roadLeft && roadRight)
        {
            roadPiece = Instantiate(Straight);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
            roadPiece.transform.Rotate(new Vector3(0, 90, 0));
        }
        // Turns
        else if (roadAbove && roadRight)
        {
            roadPiece = Instantiate(Turn);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
        }
        else if (roadBelow && roadRight)
        {
            roadPiece = Instantiate(Turn);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
            roadPiece.transform.Rotate(new Vector3(0, 90, 0));
        }
        else if (roadBelow && roadLeft)
        {
            roadPiece = Instantiate(Turn);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
            roadPiece.transform.Rotate(new Vector3(0, 180, 0));
        }
        else if (roadAbove && roadLeft)
        {
            roadPiece = Instantiate(Turn);
            roadPiece.transform.position = new Vector3(x * 4, 0, y * 4);
            roadPiece.transform.Rotate(new Vector3(0, 270, 0));
        }
        else
        {
            print("Error??? " +
                "\nDebug info: " +
                "\nPixel:" + x + ", " + y +
                "\nRoadLeft" + roadLeft +
                "\nRoadRight" + roadRight +
                "\nRoadAbove" + roadAbove +
                "\nRoadBelow" + roadBelow);
            return;
        }
        roadPiece.transform.SetParent(MapContainer.transform);
    }


    /*
    public int MapWidth;
    public int MapDepth;

    public List<GameObject> RoadPieces;

    public int Steps;

    public List<Vector3> usedPositions = new List<Vector3>();

    private int retries = 0;

    // Used for total randomness, not good!
    private void Stuff()
    {
        var currentPosition = new Vector3();
        var currentRotation = 0f;
        for (int i = 0; i < Steps; i++)
        {
            Vector3 direction;
            if (retries > 50)
                return;

            var validStep = GetValidStep(currentPosition, currentRotation, out direction);

            var roundedPosition = RoundVector3(currentPosition);
            validStep.transform.position = roundedPosition;
            RoadPieceScript rp = validStep.GetComponent<RoadPieceScript>();
            validStep.transform.Rotate(new Vector3(0, currentRotation, 0));

            usedPositions.Add(roundedPosition);
            currentPosition += direction;
            currentRotation += rp.Rotation;
        }
        print(retries);

    }

    private GameObject GetValidStep(Vector3 currentPosition, float currentRotation, out Vector3 direction)
    {
        var currentRoadPiece = RoadPieces[UnityEngine.Random.Range(0, RoadPieces.Count - 1)];
        var go = Instantiate(currentRoadPiece);
        RoadPieceScript rp = go.GetComponent<RoadPieceScript>();

        var calcDirection = Quaternion.Euler(0, currentRotation, 0) * (new Vector3(rp.Direction.x, 0, rp.Direction.y) * 4);
        direction = RoundVector3(calcDirection);

        var nextPos = currentPosition + direction;
        var checkPos = new Vector3((int)nextPos.x, (int)nextPos.y, (int)nextPos.z);

        if (usedPositions.Contains(checkPos))
        {
            retries++;
            Destroy(go);
            return GetValidStep(currentPosition, currentRotation, out direction);
        }
        else
        {
            return go;
        }
    }

    private Vector3 RoundVector3(Vector3 inputVector)
    {
        return new Vector3(Mathf.RoundToInt(inputVector.x), Mathf.RoundToInt(inputVector.y), Mathf.RoundToInt(inputVector.z));
    }

    */
}