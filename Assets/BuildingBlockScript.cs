using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildingBlockScript : MonoBehaviour
{
    public Color PrimaryColor;
    public Color SecondaryColor;
    public Color RoofColor;
    public List<MeshRenderer> MeshesToColor;

	// Use this for initialization
	void Update () {
        var primaryMaterial = new Material(Shader.Find("Standard"));
        var secondaryMaterial = new Material(Shader.Find("Standard"));
        var roofMaterial = new Material(Shader.Find("Standard"));

        primaryMaterial.color = PrimaryColor;
        secondaryMaterial.color = SecondaryColor;
        roofMaterial.color = RoofColor;

        foreach (var mesh in MeshesToColor)
        {
            if(mesh.materials.Length == 3)
                mesh.materials = new Material[] { roofMaterial, mesh.materials[1], mesh.materials[2] };
            else
                mesh.materials = new Material[] { primaryMaterial, secondaryMaterial};
        }
	}
}
