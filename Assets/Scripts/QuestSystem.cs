using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public List<Quest> doneQuests;//������ ����������� �������
    public List<Quest> activeQuests;//������ �������� �������

    public static QuestSystem Instance;

    private void Awake()
    {
        Instance = this;
    }
}
