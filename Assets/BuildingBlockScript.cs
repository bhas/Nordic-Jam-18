using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildingBlockScript : MonoBehaviour
{
    public Color PrimaryColor;
    public Color SecondaryColor;
    public List<MeshRenderer> MeshesToColor;

	// Use this for initialization
	void Update () {
        var primaryMaterial = new Material(Shader.Find("Standard"));
        var secondaryMaterial = new Material(Shader.Find("Standard"));
        primaryMaterial.color = PrimaryColor;
        secondaryMaterial.color = SecondaryColor;
        foreach (var mesh in MeshesToColor)
        {
            mesh.materials = new Material[] {primaryMaterial, secondaryMaterial };
        }
	}
}
