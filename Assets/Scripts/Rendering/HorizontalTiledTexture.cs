using UnityEngine;
using System.Collections;

[ExecuteAlways]
public class HorizontalTiledTexture : MonoBehaviour
{
    public float Scale = 1;
    private Material material;
    private Mesh mesh;

    private void Update()
    {
        if (this.material == null || this.mesh == null)
        {
            this.GetMeshAndMaterial();
        }

        if (this.material == null || this.mesh == null)
        {
            return;
        }

        material.mainTextureScale = new Vector2(mesh.bounds.size.x * transform.localScale.x * this.Scale, mesh.bounds.size.y * transform.localScale.y * this.Scale);
    }

    private void GetMeshAndMaterial()
    {
        this.material = this.GetComponent<Renderer>().sharedMaterial;
        this.mesh = GetComponent<MeshFilter>().sharedMesh;
    }
}
