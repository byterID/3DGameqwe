using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Camera mainCamera;
    [SerializeField] private LayerMask movableMask;
    [SerializeField] private Interactable focus;
    [SerializeField] private GameObject swordObject;
    [SerializeField] private GameObject shieldObject;
    public static Player Instance;
    private bool canAttack = false;
    

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;

    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movableMask))
            {
                motor.MoveToPoint(hit.point);
                RemoveFocus();

            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                var interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }


            }
        }
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        
        newFocus.OnFocused(gameObject);
    }

    private void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

    public void Heal()
    {
        currentHealth = maxHealth;
    }

    public void PickUp()
    {
        motor.StartPickUp();
    }

    public void ActivateSword()
    {
        canAttack = true;
        swordObject.SetActive(true);
    }
    public void ActivateShield()
    {
        maxHealth *= 2;
        shieldObject.SetActive(true);
    }
}
