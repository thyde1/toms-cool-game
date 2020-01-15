using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAnimatorBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Makes melee weapon cause damage on contact
        var meleeWeapon = animator.gameObject.GetComponentInChildren<MeleeBehaviour>();
        if (meleeWeapon == null)
        {
            return;
        }

        meleeWeapon.ActivateDamage();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stops melee weapon causing damage on contact
        var meleeWeapon = animator.gameObject.GetComponentInChildren<MeleeBehaviour>();
        if (meleeWeapon == null)
        {
            return;
        }

        meleeWeapon.DeactivateDamage();  
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
