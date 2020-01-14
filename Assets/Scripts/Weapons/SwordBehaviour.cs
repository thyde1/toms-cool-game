using UnityEngine;
using System.Collections;

public class SwordBehaviour : MonoBehaviour, WeaponBehaviour
{
    private Animator playerAnimator;

    public KeyCode HotKey => KeyCode.Alpha1;

    private void OnTransformParentChanged()
    {
        this.playerAnimator = this.GetComponentInParent<PlayerController>().GetComponentInChildren<Animator>();
    }

    public void Fire()
    {
        this.playerAnimator.SetTrigger("Sword Attack");
    }
}
