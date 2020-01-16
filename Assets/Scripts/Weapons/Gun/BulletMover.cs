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
        this.HandleHits(rayHits);
        this.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    private void HandleHits(RaycastHit[] rayHits)
    {
        foreach (var rayHit in rayHits)
        {
            var damageTaker = rayHit.collider.gameObject.GetComponentInParent<DamageTaker>();
            if (damageTaker != null)
            {
                damageTaker.TakeDamage(this.gameObject, rayHit.point);
            }

            var otherObjectData = rayHit.collider.gameObject.GetComponent<ObjectData>();
            if (otherObjectData != null && otherObjectData.BulletDestroyer)
            {
                Destroy(this.gameObject);
                return;
            }
        }
    }

}
