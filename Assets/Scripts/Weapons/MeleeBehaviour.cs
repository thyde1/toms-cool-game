using UnityEngine;
using System.Collections;

public abstract class MeleeBehaviour : MonoBehaviour, WeaponBehaviour
{
    private Animator playerAnimator;
    private DamageDealer damageDealer;

    public abstract KeyCode HotKey { get; }

    private void Start()
    {
        this.damageDealer = this.GetComponent<DamageDealer>();
    }

    private void OnTransformParentChanged()
    {
        this.playerAnimator = this.GetComponentInParent<PlayerController>().GetComponentInChildren<Animator>();
    }

    public void Fire()
    {
        this.playerAnimator.SetTrigger("Melee Attack");
    }

    public void ActivateDamage()
    {
        this.damageDealer.DealsDamage = true;
    }

    public void DeactivateDamage()
    {
        this.damageDealer.DealsDamage = false;
    }
}
