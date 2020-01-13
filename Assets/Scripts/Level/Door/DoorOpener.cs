using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour
{
    public float MoveBy = 1;
    public float OpenSpeed = 1;
    private float initialY;

    // Use this for initialization
    void Start()
    {
        this.initialY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < initialY + MoveBy)
        {
            this.transform.Translate(0, Time.deltaTime * this.OpenSpeed, 0);
        }
    }
}
