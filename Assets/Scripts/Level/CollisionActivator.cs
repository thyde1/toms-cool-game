using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class CollisionActivator<T> : MonoBehaviour where T : Component
{
    public GameObject[] ObjectsToActivate;
    public GameObject ActivatedBy;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!this.activated && other.gameObject == this.ActivatedBy)
        {
            foreach (var objectToActivate in this.ObjectsToActivate.Where(o => o!= null)) {
                var component = objectToActivate.AddComponent<T>();
                this.OnActivation(component);
            }

            this.activated = true;
        }
    }

    protected abstract void OnActivation(T component);
}
