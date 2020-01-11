using UnityEngine;
using System.Collections;

public class DoorOpenerActivator : CollisionActivator<DoorOpener>
{
    public float MoveBy = 10;
    public float OpenSpeed = 1;
    public AudioClip OpenSound;

    protected override void OnActivation(DoorOpener component)
    {
        component.MoveBy = this.MoveBy;
        component.OpenSpeed = this.OpenSpeed;
        if (OpenSound != null)
        {
            AudioSource.PlayClipAtPoint(this.OpenSound, component.transform.position);
        }
    }
}
