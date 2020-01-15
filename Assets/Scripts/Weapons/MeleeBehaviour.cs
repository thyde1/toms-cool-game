using UnityEngine;
using System.Collections;

public abstract class MeleeBehaviour : MonoBehaviour, WeaponBehaviour
{
    private Animator playerAnimator;

    public abstract KeyCode HotKey { get; }

    private void OnTransformParentChanged()
    {
        this.playerAnimator = this.GetComponentInParent<PlayerController>().GetComponentInChildren<Animator>();
    }

    public void Fire()
    {
        this.playerAnimator.SetTrigger("Melee Attack");
    }
}
