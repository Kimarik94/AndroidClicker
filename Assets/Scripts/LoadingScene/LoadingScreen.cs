using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen: MonoBehaviour
{
    public RectTransform portraitLayout;
    public RectTransform landscapeLayout;

    // Задержка перед переходом
    [SerializeField] private float loadDelay = 2f;

    // Имя следующей сцены
    [SerializeField] private string nextSceneName = "MainMenu"; 

    private void Start()
    {
        // Начинаем загрузку через заданное время
        Invoke(nameof(LoadNextScene), loadDelay);
    }

    // Метод загрузки следующей сцены
    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private void Update()
    {
        if (Screen.width > Screen.height) // Альбомная
        {
            portraitLayout.gameObject.SetActive(false);
            landscapeLayout.gameObject.SetActive(true);
        }
        else // Портретная
        {
            portraitLayout.gameObject.SetActive(true);
            landscapeLayout.gameObject.SetActive(false);
        }
    }
}
