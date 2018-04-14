using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildingBlockScript : MonoBehaviour
{
    [Header("Color")]
    public Material PrimaryColor;
    public Material SecondaryColor;
    public Material RoofColor;
    public List<MeshRenderer> MeshesToColor;
    [Space]
    [Header("Setting")]
    public bool ShouldBeDestroyed = false;

    void Start()
    {
        foreach(var piece in GetComponentsInChildren<DestructablePieceScript>())
        {
            piece.ShouldBeDestroyed = ShouldBeDestroyed;
        }
    }

    // Use this for initialization
    void Update () {
        foreach (var mesh in MeshesToColor)
        {
            if(mesh.sharedMaterials.Length == 3)
                mesh.sharedMaterials = new Material[] { RoofColor, mesh.sharedMaterials[1], mesh.sharedMaterials[2] };
            else
                mesh.sharedMaterials = new Material[] { PrimaryColor, SecondaryColor };
        }
	}
}
