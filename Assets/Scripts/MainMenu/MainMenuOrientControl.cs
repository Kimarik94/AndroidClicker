using UnityEngine;

public class MainMenuOrientControl : MonoBehaviour
{
    public RectTransform portraitLayout;
    public RectTransform landscapeLayout;

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
