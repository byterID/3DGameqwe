using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float interactRadius = 2f;
    private bool isFocus = false;
    private Transform subject;

    private bool hasInteracted = false;
    public abstract void Interact();
    
    private void Update()
    {
        if(isFocus == true && hasInteracted == false)
        {
            float distance = Vector3.Distance(transform.position, subject.position);
            if(distance <= interactRadius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform subjectTransform)
    {
        isFocus = true;
        subject = subjectTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        subject = null;
        hasInteracted = false;
    }
}
