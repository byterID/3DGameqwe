using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Interactable
{
    public override void Interact()
    {
        print(gameObject.name);
    }
}