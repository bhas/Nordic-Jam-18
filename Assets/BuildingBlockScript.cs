using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlockScript : MonoBehaviour
{
    public Color Color;
    public List<MeshRenderer> MeshesToColor;

	// Use this for initialization
	void Start () {
        var material = new Material(Shader.Find("Standard"));
        material.color = Color;
        foreach (var mesh in MeshesToColor)
        {
            mesh.material = material;
        }
	}
}
