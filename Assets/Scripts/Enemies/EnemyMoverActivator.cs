using UnityEngine;
using System.Collections;

public class EnemyMoverActivator : CollisionActivator<EnemyMover>
{
    public float MoveSpeed;

    protected override void OnActivation(EnemyMover component)
    {
        component.MoveSpeed = this.MoveSpeed;
    }
}