using UnityEngine;

public class GameSceneOrientControl : MonoBehaviour
{
    public RectTransform portraitLayout;
    public RectTransform landscapeLayout;

    public bool portraitActive;
    public bool landscapeActive;

    private void Update()
    {
        if (Screen.width > Screen.height) // Альбомная
        {
            gameObject.GetComponent<BubbleSpawner>().CountControl();
            portraitLayout.gameObject.SetActive(false);
            portraitActive = false;

            landscapeLayout.gameObject.SetActive(true);
            landscapeActive = true;

            
        }
        else // Портретная
        {
            gameObject.GetComponent<BubbleSpawner>().CountControl();
            portraitLayout.gameObject.SetActive(true);
            portraitActive = true;

            landscapeLayout.gameObject.SetActive(false);
            landscapeActive = false;
        }
    }
}
