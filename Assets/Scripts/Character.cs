using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentMotor))]
public class Character : Interactable 
{
    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] protected float currentHealth;
    [SerializeField] private float damage = 20f;
    protected AgentMotor motor;

    private void Start()
    {
        motor = GetComponent<AgentMotor>();
        currentHealth = maxHealth;
    }
    public override void Interact(GameObject subject)
    {
        var character = subject.GetComponent<Character>();
        if (character != null)
        {
            print($"{subject.name} בüוע {gameObject.name}!");
            TakeDamage(character.damage);
        }
    }

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
        print($"Çהמנמגüו {gameObject.name}: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print($"{gameObject.name} ףלונ!");
        Destroy(gameObject);
    }
}
