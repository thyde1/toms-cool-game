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
        if ((other.gameObject.GetComponent<ObjectData>()?.BulletDestroyer).GetValueOrDefault(false))
        {
            Destroy(this.gameObject);
        }
    }
}
