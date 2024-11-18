using System.Collections.Generic;
using UnityEngine;

public class LoadingProgress : MonoBehaviour
{
    //Список для "Кружков"-префабов загрузки
    private List<GameObject> points = new List<GameObject>();
    public GameObject pointPrefab;

    //Параметры индикатра загрузки
    public float radius = 50f;
    public int numberOfPoints = 13;
    public float rotationSpeed = -80f;

    private void Start()
    {
        SpanwPointsLoad();
    }

    private void Update()
    {
        RotateAround();
    }

    //Метод для создания на старте сцены индикатора загрузки
    private void SpanwPointsLoad()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfPoints;
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);

            GameObject point = Instantiate(pointPrefab, transform);
            points.Add(point);

            point.transform.localPosition = position;
        }
    }

    //Метод вращения индикатора загрузки через общий Rect
    private void RotateAround()
    {
        gameObject.GetComponent<RectTransform>().Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
