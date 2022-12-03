using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class AgentAnimator : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Transform target;
    

    public enum AnimStates { Idle, Walk, PickUp, Attack}//ввожу названия анимаций
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void SetAnimState(AnimStates animState)//устанавливает стадию анимации
    {
        animator.SetInteger("State", (int)animState);
    }
}
