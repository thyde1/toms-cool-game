using UnityEngine;
using System.Collections;

public class HorizontalTiledTexture : MonoBehaviour
{
    public float Scale = 1;

    void Start()
    {
        var material = this.GetComponent<Renderer>().material;
        var mesh = GetComponent<MeshFilter>().mesh;
        material.mainTextureScale = new Vector2(mesh.bounds.size.x * transform.localScale.x * this.Scale, mesh.bounds.size.y * transform.localScale.y * this.Scale);
    }
}
