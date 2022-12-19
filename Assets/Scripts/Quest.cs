using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int id;
    new public string name = "Test Quest";
    [Multiline]public string descrption = "Do something!";
    public int coinsReward = 10;
    public List<GameObject> enemies;
    private int enemyCount;
    public bool isDone = false;
    private bool isActive = false;

    private void Start()
    {
        enemyCount = enemies.Count;
    }

    public void StartQuest()//������ ������
    {
        if (isActive == false)
        {
            QuestSystem.Instance.activeQuests.Add(this);//���������� ������ � ������ ��������
            float areaLenght = 5f;
            foreach(var enemy in enemies)//����� ������ � ������������ �����
            {
                float posX = transform.position.x + (areaLenght / 2) * Random.Range(-1, 1);
                float posZ = transform.position.z + (areaLenght / 2) * Random.Range(-1, 1);
                var newEnemy = Instantiate(enemy, new Vector3(posX, transform.position.y, posZ), Quaternion.identity);
                newEnemy.GetComponent<Enemy>().quest = this;
            }
            isActive = true;
            print($"������� �����{name}");
            print($"��������:{descrption}");
            print($"�������: {coinsReward} �����");
        }
    }

    public void OnEnemyDead()//���������� ������ ������� ���� ����� � ������ ������ �����������
    {
        enemyCount--;
        if (enemyCount <= 0)
            QuestDone();
    }

    private void QuestDone()//����� ��������� � ������ ����������
    {
        Player.Instance.AddCoins(coinsReward);
        isDone = true;
        isActive = false;
        QuestSystem.Instance.activeQuests.Remove(this);
        QuestSystem.Instance.doneQuests.Add(this);
        print("����� ��������");
    }
}
