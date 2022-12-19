using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;//переменная для задания выпадающего списка с разрешениями
    private Resolution[] resolutions;//библиотека разрешений для их автоматической генерации если такое разрешение есть на устройстве
    public GameObject MainMusic;//мой компонент для добавления музыки на задний фон, чтобы она не переносилась на следующую сцену
    private AudioSource audioSource;
    private float musicVolume = 1f;

    private void Start()
    {
        audioSource = MainMusic.GetComponent<AudioSource>();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolitionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)//формирование массива с разрешениями экрана и добавление их в выпадающий список
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)//и установка разрешения, которое изначально стоит на устройстве
            {
                currentResolitionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolitionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    private void Update()
    {
        audioSource.volume = musicVolume;
    }
    public void SetVolume (float volume)//установка громкости
    {
        SoundEffects.Instance.audioSource.volume = volume;
        musicVolume = volume;
    }

    public void SetQuality(int qualityIndex)//установка качества графики из настроек quality
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)//установка полноэкранного режима
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)//установка выбранного разрешения динамически
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
