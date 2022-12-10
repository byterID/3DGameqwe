using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour//скрипт, управляющий взаимодействием всего со всем
{
    public float interactRadius = 2f;//работает если кликнуть в радиусе 2 изм ед юнити
    protected bool isFocus = false;//переменная для задавания фокуса
    protected GameObject subject;//объект следования

    private bool hasInteracted = false;
    public abstract void Interact(GameObject subject);
    
    protected virtual void Update()//тут происходит проверка достижения нужной дистанции для взаимодействия
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

    public void OnFocused(GameObject newSubject)//Добавление нового объекта для следования при нажатии
    {
        isFocus = true;
        subject = newSubject;
        hasInteracted = false;
    }
    public void OnDefocused()//удаление объекта следования
    {
        isFocus = false;
        subject = null;
        hasInteracted = false;
    }
}
