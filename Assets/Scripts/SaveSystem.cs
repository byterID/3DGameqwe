using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void DeleteAllSavings()
    {
        PlayerPrefs.DeleteAll();
    }
    public static void SetPlayerPosition(Vector3 position)//беру позицию в которой находится игрок
    {
        PlayerPrefs.SetFloat("PlayerPositionX", position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", position.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", position.z);
    }
    public static Vector3 GetPlayerPosition()//сохраняет позицию в ключи
    {
        if (PlayerPrefs.HasKey("PlayerPositionX"))
        {
            return new Vector3(PlayerPrefs.GetFloat("PlayerPositionX"),
                PlayerPrefs.GetFloat("PlayerPositionY"),
                PlayerPrefs.GetFloat("PlaerPositionZ"));
        }
        else
        {
            return new Vector3(0f, 0.36f, 15.7f);//если ничего не сохранялось, игрок будет спавниться в начальном положении
        }
    }

    public static void SetDoneQuests(List<Quest> quests)//сохраняет прогресс выполнения квестов
    {
        foreach (var quest in quests)
            PlayerPrefs.SetInt($"Quest{quest.id}", 1);
    }
}
