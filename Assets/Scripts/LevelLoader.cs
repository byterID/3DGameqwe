using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;//когда начинается загрузка, будет активироваться панель со слайдером
    [SerializeField] private Slider slider;//переменная слайдера

    public void LoadLevel(int sceneIndex)//параметр для указания, какую сцену надо загрузить
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);//слайдер берет переменную для заполнения и заполняется по мере загрузки сцены
        loadingScreen.SetActive(true);
        while (operation.isDone == false)
        {
            float progress = operation.progress;
            slider.value = progress;
            yield return null;
        }
    }
}
