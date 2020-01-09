using UnityEngine;
using System.Collections;
using System.Linq;

public class DamageTaker : MonoBehaviour
{
    public GameObject DeathObject;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        this.DealDamage(hit.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.DealDamage(other.gameObject);
    }

    private void DealDamage(GameObject other)
    {
        var otherObjectData = other.GetComponent<ObjectData>();
        if (!otherObjectData)
        {
            return;
        }
        var isPlayer = this.GetComponent<PlayerController>() != null;
        if (isPlayer && !otherObjectData.DealsDamageToPlayer)
        {
            return;
        }

        if (!isPlayer && otherObjectData.DealsDamageToPlayer)
        {
            return;
        }

        if (otherObjectData.DealsDamage)
        {
            var objectCamera = this.GetComponentInChildren<Camera>();
            if (objectCamera != null)
            {
                objectCamera.transform.parent = null;
            }

            Destroy(this.gameObject);
            var deathObject = this.DeathObject;
            if (deathObject != null)
            {
                Instantiate(deathObject, this.transform.position, this.transform.rotation);
            }
        }
    }
}
