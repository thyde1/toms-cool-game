using UnityEngine;
using System.Collections;

public class DebrisCollisionIgnorer : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var otherObjectData = hit.collider.GetComponentInParent<ObjectData>();
        if (!otherObjectData)
        {
            return;
        }

        if (!otherObjectData.CollidesWithCharacters)
        {
            Physics.IgnoreCollision(hit.collider, this.GetComponent<CharacterController>());
        }
    }
}
