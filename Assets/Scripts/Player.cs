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
    [SerializeField] private int coinsCount;
    
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
        canAttack = false;
        transform.position = SaveSystem.GetPlayerPosition();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0))//на нажатие левой кнопки мыши, игрок просто гуляет по миру
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movableMask))
            {
                motor.MoveToPoint(hit.point);
                RemoveFocus();

            }
        }
        else if (Input.GetMouseButtonDown(1))//на правую кнопку мыши нажимать на объект взаимодействия
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            SaveSystem.SetPlayerPosition(transform.position);
        }
    }

    private void SetFocus(Interactable newFocus)//установление фокуса для игрока
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

    private void RemoveFocus()//удаление фокуса
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

    public void Heal()//лечение до максимума
    {
        currentHealth = maxHealth;
    }

    public void PickUp()//подбор объектов
    {
        motor.StartPickUp();
    }

    public void ActivateSword()//получение возможности атаковать, при подборе меча
    {
        canAttack = true;
        swordObject.SetActive(true);
    }
    public void ActivateShield()//увеличение хп в 2 раза при подборе щита
    {
        maxHealth *= 2;
        shieldObject.SetActive(true);
    }

    protected override void Die()
    {
        Time.timeScale = 0;
    }
    public void AddCoins(int coins)//начисление монеток за выполенное задание
    {
        coinsCount += coins;
        print($"Вы получили {coinsCount} монет");
    }
}
