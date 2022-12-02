using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(AgentAnimator))]
public class AgentMotor : MonoBehaviour
{
    private NavMeshAgent agent;
    private AgentAnimator animator;
    private Transform target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<AgentAnimator>();
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            LookAtTarget();
        }
        if (agent.velocity.magnitude == 0)
            animator.SetAnimState(AgentAnimator.AnimStates.Idle);
        else
            animator.SetAnimState(AgentAnimator.AnimStates.Walk);
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.interactRadius;
        agent.updateRotation = false;

        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    private void LookAtTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }
}
