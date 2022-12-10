using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float interactRadius = 2f;
    private bool isFocus = false;
    protected GameObject subject;

    private bool hasInteracted = false;
    public abstract void Interact(GameObject subject);
    
    protected virtual void Update()
    {
        if(isFocus == true && hasInteracted == false)
        {
            float distance = Vector3.Distance(transform.position, subject.transform.position);
            if(distance <= interactRadius)
            {
                Interact(subject);
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(GameObject newSubject)
    {
        isFocus = true;
        subject = newSubject;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        subject = null;
        hasInteracted = false;
    }
}
