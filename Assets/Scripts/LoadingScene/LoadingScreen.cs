using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen: MonoBehaviour
{
    public RectTransform portraitLayout;
    public RectTransform landscapeLayout;

    // �������� ����� ���������
    [SerializeField] private float loadDelay = 2f;

    // ��� ��������� �����
    [SerializeField] private string nextSceneName = "MainMenu"; 

    private void Start()
    {
        // �������� �������� ����� �������� �����
        Invoke(nameof(LoadNextScene), loadDelay);
    }

    // ����� �������� ��������� �����
    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private void Update()
    {
        if (Screen.width > Screen.height) // ���������
        {
            portraitLayout.gameObject.SetActive(false);
            landscapeLayout.gameObject.SetActive(true);
        }
        else // ����������
        {
            portraitLayout.gameObject.SetActive(true);
            landscapeLayout.gameObject.SetActive(false);
        }
    }
}
