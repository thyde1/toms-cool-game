using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float Speed = 1;

    // Update is called once per frame
    void Update()
    {
        var rayHits = Physics.RaycastAll(this.transform.position, transform.TransformDirection(Vector3.forward), Time.deltaTime * Speed);
        var hitColliders = rayHits.Select(h => h.collider);
        this.HandleHits(hitColliders);
        this.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    private void HandleHits(IEnumerable<Collider> others)
    {
        foreach (var other in others)
        {
            var damageTaker = other.gameObject.GetComponentInParent<DamageTaker>();
            if (damageTaker != null)
            {
                damageTaker.TakeDamage(this.gameObject);
            }

            var otherObjectData = other.gameObject.GetComponent<ObjectData>();
            if (otherObjectData != null && otherObjectData.BulletDestroyer)
            {
                Destroy(this.gameObject);
                return;
            }
        }
    }

}
