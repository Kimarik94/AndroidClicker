using System.Collections;
using TMPro;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public RectTransform canvasTransform;

    private int clickCount = 0;

    //Для подсчета кликов.
    public GameObject clickCountPortrait;
    public GameObject clickCountLandscape;

    public void SpawnBubbles(Vector2 screenPosition)
    {
        // Генерируем случайное количество пузырьков (от 1 до 3)
        int bubbleCount = Random.Range(1, 4);

        for (int i = 0; i < bubbleCount; i++)
        {
            // Немного сдвигаем позицию каждого пузырька случайным образом
            Vector2 randomOffset = new Vector2(Random.Range(-50f, 50f), Random.Range(-50f, 50f));
            Vector2 bubblePosition = screenPosition + randomOffset;

            // Переводим экранные координаты в координаты Canvas
            Vector2 anchoredPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform, bubblePosition, null, out anchoredPosition);

            // Создаем пузырек
            GameObject bubble = Instantiate(bubblePrefab, canvasTransform);
            RectTransform bubbleRect = bubble.GetComponent<RectTransform>();
            bubbleRect.anchoredPosition = anchoredPosition;

            // Настраиваем случайный размер
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

            // Начинаем движение пузырька по синусоиде
            StartCoroutine(MoveBubbleSinusoidal(bubbleRect));
        }
    }

    private IEnumerator MoveBubbleSinusoidal(RectTransform bubble)
    {
        Vector3 startPos = bubble.anchoredPosition;
        float amplitude = Random.Range(25f, 75f); // Амплитуда синусоиды
        float frequency = Random.Range(2f, 4f);    // Частота синусоиды
        float verticalDistance = Random.Range(100f, 250f); // Дистанция по вертикали

        float time = 0;
        float duration = 2f; // Время жизни пузырька

        CanvasGroup canvasGroup = bubble.GetComponent<CanvasGroup>();

        while (time < duration)
        {
            time += Time.deltaTime;

            // Движение по синусоиде
            float xOffset = Mathf.Sin(time * frequency) * amplitude;
            float yOffset = verticalDistance * (time / duration);
            bubble.anchoredPosition = startPos + new Vector3(xOffset, yOffset, 0);

            // Плавное исчезновение
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
        // Для сенсорного ввода на мобильном
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

        // Для тестов на ПК
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
