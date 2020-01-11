using UnityEngine;
using System.Collections;

public class Transparentizable : MonoBehaviour
{
    public Material TransparentMaterial;

    private Material originalMaterial;

    private bool currentlyTransparent = false;

    public void Transparentize()
    {
        if (this.currentlyTransparent)
        {
            return;
        }
        var renderer = this.gameObject.GetComponent<Renderer>();
        this.originalMaterial = renderer.material;
        renderer.material = this.TransparentMaterial;
        this.currentlyTransparent = true;
    }

    public void Untransparentize()
    {
        if (!this.currentlyTransparent)
        {
            return;
        }
        var renderer = this.gameObject.GetComponent<Renderer>();
        renderer.material = this.originalMaterial;
        this.currentlyTransparent = false;
    }
}
