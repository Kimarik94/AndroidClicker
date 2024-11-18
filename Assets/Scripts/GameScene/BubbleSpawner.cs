using System.Collections;
using TMPro;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public RectTransform canvasTransform;

    private int clickCount = 0;

    //��� �������� ������.
    public GameObject clickCountPortrait;
    public GameObject clickCountLandscape;

    public void SpawnBubbles(Vector2 screenPosition)
    {
        // ���������� ��������� ���������� ��������� (�� 1 �� 3)
        int bubbleCount = Random.Range(1, 4);

        for (int i = 0; i < bubbleCount; i++)
        {
            // ������� �������� ������� ������� �������� ��������� �������
            Vector2 randomOffset = new Vector2(Random.Range(-50f, 50f), Random.Range(-50f, 50f));
            Vector2 bubblePosition = screenPosition + randomOffset;

            // ��������� �������� ���������� � ���������� Canvas
            Vector2 anchoredPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform, bubblePosition, null, out anchoredPosition);

            // ������� �������
            GameObject bubble = Instantiate(bubblePrefab, canvasTransform);
            RectTransform bubbleRect = bubble.GetComponent<RectTransform>();
            bubbleRect.anchoredPosition = anchoredPosition;

            // ����������� ��������� ������
            if (gameObject.GetComponent<GameSceneOrientControl>().portraitActive)
            {
                float size = Random.Range(50f, 150f);
                bubbleRect.sizeDelta = new Vector2(size, size);
            }
            else if(gameObject.GetComponent<GameSceneOrientControl>().landscapeActive)
            {
                float size = Random.Range(25f, 75);
                bubbleRect.sizeDelta = new Vector2(size, size);
            }

            // �������� �������� �������� �� ���������
            StartCoroutine(MoveBubbleSinusoidal(bubbleRect));
        }
    }

    private IEnumerator MoveBubbleSinusoidal(RectTransform bubble)
    {
        Vector3 startPos = bubble.anchoredPosition;
        float amplitude = Random.Range(25f, 75f); // ��������� ���������
        float frequency = Random.Range(2f, 4f);    // ������� ���������
        float verticalDistance = Random.Range(100f, 250f); // ��������� �� ���������

        float time = 0;
        float duration = 2f; // ����� ����� ��������

        CanvasGroup canvasGroup = bubble.GetComponent<CanvasGroup>();

        while (time < duration)
        {
            time += Time.deltaTime;

            // �������� �� ���������
            float xOffset = Mathf.Sin(time * frequency) * amplitude;
            float yOffset = verticalDistance * (time / duration);
            bubble.anchoredPosition = startPos + new Vector3(xOffset, yOffset, 0);

            // ������� ������������
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1f - (time / duration);
            }

            yield return null;
        }

        Destroy(bubble.gameObject);
    }

    void Start()
    {

        if (gameObject.GetComponent<GameSceneOrientControl>().portraitActive)
        {
            clickCountPortrait.GetComponent<TextMeshPro>().text = clickCount.ToString();
        }
        else if (gameObject.GetComponent<GameSceneOrientControl>().landscapeActive)
        {
            clickCountLandscape.GetComponent<TextMeshPro>().text = clickCount.ToString();
        }
    }

    void Update()
    {
        // ��� ���������� ����� �� ���������
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    SpawnBubbles(touch.position);
                    clickCount++;
                    CountControl();
                    GameObject.Find("SceneManager").GetComponent<AudioControl>().PlayBubbleSound();
                }
            }
        }

        // ��� ������ �� ��
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            SpawnBubbles(mousePosition);
        }
    }

    public void CountControl()
    {
        if (gameObject.GetComponent<GameSceneOrientControl>().portraitActive)
        {
            clickCountPortrait.GetComponent<TextMeshProUGUI>().text = clickCount.ToString();
        }
        else if (gameObject.GetComponent<GameSceneOrientControl>().landscapeActive)
        {
            clickCountLandscape.GetComponent<TextMeshProUGUI>().text = clickCount.ToString();
        }
    }
}
