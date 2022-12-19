using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public List<Quest> doneQuests;//список выполненных квестов
    public List<Quest> activeQuests;//список активных квестов

    public static QuestSystem Instance;

    private void Awake()
    {
        Instance = this;
    }
}
