using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
    public Texture Texture;
    public float Size = 10;

    private Camera playerCamera;

    // Use this for initialization
    void Start()
    {
        this.playerCamera = Object.FindObjectOfType<Camera>();
    }

    private void OnGUI()
    {
        var screenPosition = this.playerCamera.WorldToScreenPoint(this.transform.position);
        GUI.DrawTexture(new Rect(new Vector2(screenPosition.x - this.Size / 2, Screen.height - screenPosition.y - this.Size / 2), new Vector2(this.Size, this.Size)), this.Texture);
    }
}
