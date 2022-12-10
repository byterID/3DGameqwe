using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentMotor))]
public class Character : Interactable //������ ��� ������������ ��� ����� �������� �� ����� ��� ������
{
    [SerializeField] protected float maxHealth = 100f;//������������ �� ������
    [SerializeField] protected float currentHealth;//����������� �� 
    [SerializeField] private float damage = 20f;//�����, ������� ������� �����
    [SerializeField] private float attackSpeed = 1f;//�������� �����
    [SerializeField] protected bool canAttack = true;//�� �����
    protected AgentMotor motor;//���������� ����������

    private void Start()
    {
        motor = GetComponent<AgentMotor>();
        currentHealth = maxHealth;
    }
    public override void Interact(GameObject subject)
    {
        StartCoroutine(OnInteracting(subject));
    }

    private IEnumerator OnInteracting(GameObject subject)//���������� ���������������
    {
        var character = subject.GetComponent<Character>();//���������� ��� ������ ���������� Character
        if (character != null)//���� � ������� ���� ������ �������������
        {
            if (character.canAttack == true)//� ���� �� ����� ���������(�� ����� ������)
            {
                while (isFocus == true)//� �� ��� ��� ���� ������� ��� ����� �� �������
                {
                    if (Vector3.Distance(transform.position, subject.transform.position) <= interactRadius)//���� �������� ��������� �� ����
                    {
                        print($"{subject.name} ���� {gameObject.name}!");//� ���������� ��������
                        TakeDamage(character.damage);
                        character.Attack();
                        yield return new WaitForSeconds(character.attackSpeed);//� ��� ��������� �� ����� �������, ����� �������� �������� �� ��������� ����������
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


    private void TakeDamage(float damage)//������ ������� ��� 0 ��������
    {
        currentHealth -= damage;
        print($"�������� {gameObject.name}: {currentHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()//�������� ������� �� �����
    {
        print($"{gameObject.name} ����!");
        Destroy(gameObject);
    }
}
