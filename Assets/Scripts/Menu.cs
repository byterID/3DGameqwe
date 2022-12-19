using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Exit()//выход из игры
    {
        Application.Quit();
    }

    public void PlayButtonClickSound()//параметр для проигрывания щелчка при нажатии на кнопку
    {
        SoundEffects.Instance.audioSource.PlayOneShot(SoundEffects.Instance.buttonClick);
    }

    public void NewGame()
    {
        SaveSystem.DeleteAllSavings();
    }
}
