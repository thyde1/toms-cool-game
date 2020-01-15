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
        this.damageDealer.OnDamageDealt.AddListener(OnDamageDealt);
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
        this.damageDealer.ClearInvulnerableTakers();
    }

    private void OnDamageDealt(DamageTaker taker)
    {
        this.damageDealer.MakeTakerInvulnerable(taker);
    }
}
