using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Interactable
{
    public override void Interact(GameObject subject)
    {
        Player.Instance.PickUp();
        Player.Instance.ActivateShield();
        Destroy(gameObject);
    }
}
