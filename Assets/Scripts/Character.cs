using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentMotor))]
public class Character : Interactable //скрипт для отслеживания еще живых объектов на сцене для врагов
{
    [SerializeField] protected float maxHealth = 100f;//максимальное хп игрока
    [SerializeField] protected float currentHealth;//обновляемое хп 
    [SerializeField] private float damage = 20f;//дамаг, который наносит игрок
    [SerializeField] private float attackSpeed = 1f;//скорость атаки
    [SerializeField] protected bool canAttack = true;//кд атаки
    protected AgentMotor motor;//управление действиями

    private void Start()
    {
        motor = GetComponent<AgentMotor>();
        currentHealth = maxHealth;
    }
    public override void Interact(GameObject subject)
    {
        StartCoroutine(OnInteracting(subject));
    }

    private IEnumerator OnInteracting(GameObject subject)//управление взаимодействием
    {
        var character = subject.GetComponent<Character>();//переменная для записи компонента Character
        if (character != null)//если у объекта есть объект преследования
        {
            if (character.canAttack == true)//и если он может атаковать(кд удара прошло)
            {
                while (isFocus == true)//и до тех пор пока активен его фокус на объекте
                {
                    if (Vector3.Distance(transform.position, subject.transform.position) <= interactRadius)//идет проверка дистанции до цели
                    {
                        print($"{subject.name} бьет {gameObject.name}!");//и происходит избиение
                        TakeDamage(character.damage);
                        character.Attack();
                        yield return new WaitForSeconds(character.attackSpeed);//а тут настройка кд между ударами, чтобы анимация успевала за реальными движениями
                    }
                    yield return null;
                }
            }
        }
    }

    public void Attack()
    {
        motor.StartAttack(attackSpeed);
    }


    private void TakeDamage(float damage)//объект умирает при 0 здоровья
    {
        currentHealth -= damage;
        print($"Здоровье {gameObject.name}: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()//удаление объекта со сцены
    {
        print($"{gameObject.name} умер!");
        Destroy(gameObject);
    }
}
