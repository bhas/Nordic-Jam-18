using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour {
    public int mapSize;
    public float parkPercentage;
    public float roadPercentage;
    public float buildingPercentage;

    

   




	// Use this for initialization
	void Start () {
	float totalPercentage = parkPercentage + roadPercentage + buildingPercentage;
        float pP = parkPercentage / totalPercentage;
        float rP = roadPercentage / totalPercentage;
        float bP = buildingPercentage / totalPercentage;

        Generate(pP, rP, bP);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate(float p1, float p2, float p3)
    {
        float AP = p1 + p3; 




    }
}
