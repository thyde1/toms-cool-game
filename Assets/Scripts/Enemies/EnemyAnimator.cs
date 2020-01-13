using UnityEngine;
using System.Collections;

public class EnemyAnimator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var animator = this.GetComponent<Animator>();
        var target = this.GetComponentInParent<EnemyMover>()?.Target;
        if (target == null)
        {
            // Taunt if you're dead
            animator.SetTrigger("Taunt");
            return;
        }
        if (target != null)
        {
            animator.SetTrigger("Walk");
        }
    }
}
