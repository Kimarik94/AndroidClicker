using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    private string nextSceneName = "GameScene";

    [SerializeField] Button StartBtn;
    [SerializeField] Button OptionsBtn;
    [SerializeField] Button ExitBtn;

    [SerializeField] private GameObject OptionsPanel;

    public void Start()
    {
        //��������� ��������� �� ������ ��� ������� �� ������
        StartBtn.onClick.AddListener(LoadGame);
        OptionsBtn.onClick.AddListener(OptionsPanelOpen);
        ExitBtn.onClick.AddListener(ExitGame);
    }

    //����� �������� ���� �����
    private void OptionsPanelOpen()
    {
        OptionsPanel.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    //����� ������� �������� ����� ����
    private void LoadGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    //����� ������ �� ����
    private void ExitGame()
    {
        Application.Quit();
    }
}
