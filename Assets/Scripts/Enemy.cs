using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentMotor))]
public class Enemy : MonoBehaviour
{
    private AgentMotor motor;
    [SerializeField] private Interactable focus;
    [SerializeField] private float agreRadius = 10f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agreRadius);
    }

    private void Start()
    {
        motor = GetComponent<AgentMotor>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.Instance.transform.position);
        if(distance <= agreRadius)
        {
            if(focus == null)
                SetFocus(Player.Instance.GetComponent<Interactable>());
        }
        else if (focus != null)
        {
            RemoveFocus();
        }
    }
    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}
