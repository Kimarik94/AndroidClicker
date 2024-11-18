using UnityEngine;
using UnityEngine.UI;

public class PanelsOrientControl : MonoBehaviour
{
    [SerializeField] Button exitButton;

    private void OnEnable()
    {
        exitButton.onClick.AddListener(Application.Quit);
    }
}
