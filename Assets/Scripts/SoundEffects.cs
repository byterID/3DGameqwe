using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClick;//звук нажатий на кнопку
    public AudioClip backgroundMusic;//музыка для заднего фона
    public static SoundEffects Instance;//проигрывание звуков

    private void Awake()//сохранения компонента во время перехода на другую сцену
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }
}
