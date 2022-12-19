using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;//���������� ��� ������� ����������� ������ � ������������
    private Resolution[] resolutions;//���������� ���������� ��� �� �������������� ��������� ���� ����� ���������� ���� �� ����������
    public GameObject MainMusic;//��� ��������� ��� ���������� ������ �� ������ ���, ����� ��� �� ������������ �� ��������� �����
    private AudioSource audioSource;
    private float musicVolume = 1f;

    private void Start()
    {
        audioSource = MainMusic.GetComponent<AudioSource>();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolitionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)//������������ ������� � ������������ ������ � ���������� �� � ���������� ������
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)//� ��������� ����������, ������� ���������� ����� �� ����������
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
    public void SetVolume (float volume)//��������� ���������
    {
        SoundEffects.Instance.audioSource.volume = volume;
        musicVolume = volume;
    }

    public void SetQuality(int qualityIndex)//��������� �������� ������� �� �������� quality
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)//��������� �������������� ������
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)//��������� ���������� ���������� �����������
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
