﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class DamageTaker : MonoBehaviour
{
    public GameObject DeathObject;
    public GameObject HitObject;
    public AudioClip DeathSound;
    public AudioClip DamageSound;
    public float Health = 1;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        this.TakeDamage(hit.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.TakeDamage(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.TakeDamage(collision.gameObject);
    }

    public void TakeDamage(GameObject other, Vector3? impactPosition = null)
    {
        if (impactPosition == null)
        {
            impactPosition = other.transform.position;
        }

        var otherObjectData = other.GetComponent<ObjectData>();
        if (!ShouldTakeDamage(otherObjectData))
        {
            return;
        }

        this.Health -= otherObjectData.DamageValue;
        if (this.HitObject != null)
        {
            Instantiate(this.HitObject, impactPosition.Value, Quaternion.identity);
        }

        if (this.Health <= 0)
        {
            this.Die();
        }
        else
        {
            if (this.DamageSound != null)
            {
                AudioSource.PlayClipAtPoint(this.DamageSound, this.transform.position);
            }
        }
    }

    private bool ShouldTakeDamage(ObjectData otherObjectData)
    {
        if (otherObjectData == null)
        {
            return false;
        }

        if (!otherObjectData.DealsDamage)
        {
            return false;
        }

        if (!otherObjectData)
        {
            return false;
        }
        var isPlayer = this.GetComponent<PlayerController>() != null;
        if (isPlayer && !otherObjectData.DealsDamageToPlayer)
        {
            return false;
        }

        if (!isPlayer && otherObjectData.DealsDamageToPlayer)
        {
            return false;
        }

        return true;
    }

    private void Die()
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

        if (this.DeathSound != null)
        {
            AudioSource.PlayClipAtPoint(this.DeathSound, this.transform.position);
        }
    }
}
