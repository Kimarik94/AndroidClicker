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
        //Добавляем слушателя на методы при нажатии на кнопку
        StartBtn.onClick.AddListener(LoadGame);
        OptionsBtn.onClick.AddListener(OptionsPanelOpen);
        ExitBtn.onClick.AddListener(ExitGame);
    }

    //Метод открытия окна опций
    private void OptionsPanelOpen()
    {
        OptionsPanel.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    //Метод загузки основной сцены игры
    private void LoadGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    //Метод выхода из игры
    private void ExitGame()
    {
        Application.Quit();
    }
}
