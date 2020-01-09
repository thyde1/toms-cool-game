using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float Speed = 1;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        var otherObjectData = other.gameObject.GetComponent<ObjectData>();
        if (otherObjectData == null)
        {
            return;
        }

        if (otherObjectData.BulletDestroyer)
        {
            Destroy(this.gameObject);
        }

        if (otherObjectData.DestroyedByBullets)
        {
            Destroy(other.gameObject);

            var deathObject = otherObjectData.DeathObject;
            if (deathObject != null)
            {
                Instantiate(deathObject, other.transform.position, other.transform.rotation);
            }
        }
    }
}
