using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Interactable
{
    [SerializeField] private Quest quest;//ввожу переменную квеста
    public override void Interact(GameObject subject)
    {
        quest.StartQuest();//при взаимодейстивии с нпс запустится квест
    }
}
