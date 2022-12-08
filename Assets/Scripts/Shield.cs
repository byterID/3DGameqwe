using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Interactable
{
    public override void Interact()
    {
        Player.Instance.PickUp();
        Player.Instance.ActivateShield();
        Destroy(gameObject);
    }
}
