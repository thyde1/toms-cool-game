using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class DamageDealtEvent : UnityEvent<DamageTaker> { }

public class DamageDealer : MonoBehaviour
{
    public bool DealsDamage = false;

    public bool DealsDamageToPlayer = false;

    public float DamageValue = 1;

    public DamageDealtEvent OnDamageDealt = new DamageDealtEvent();

    private IList<DamageTaker> invulnerableTakers = new List<DamageTaker>();

    public float GetDamage(DamageTaker taker)
    {
        if (this.invulnerableTakers.Contains(taker))
        {
            return 0;
        }

        return this.DamageValue;
    }

    public void DamageDealt(DamageTaker taker)
    {
        this.OnDamageDealt.Invoke(taker);
    }

    public void MakeTakerInvulnerable(DamageTaker taker)
    {
        this.invulnerableTakers.Add(taker);
    }

    public void ClearInvulnerableTakers()
    {
        this.invulnerableTakers.Clear();
    }
}
