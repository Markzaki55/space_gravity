using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaurdian_atackplayer : StateMachineBehaviour
{
    [SerializeField] Guardianboss guardianboss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        guardianboss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Guardianboss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        guardianboss.AttackPlayerState();
    }
}
