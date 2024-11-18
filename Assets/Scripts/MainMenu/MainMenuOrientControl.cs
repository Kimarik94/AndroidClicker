using UnityEngine;

public class MainMenuOrientControl : MonoBehaviour
{
    public RectTransform portraitLayout;
    public RectTransform landscapeLayout;

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
