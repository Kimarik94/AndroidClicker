using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuLogic : MonoBehaviour
{
    private RectTransform rectTr;
    [SerializeField] private Button okBtn;

    public void Start()
    {
        rectTr = GetComponent<RectTransform>();
        rectTr.localScale = Vector3.zero;

        okBtn.onClick.AddListener(CloseOptionPanel);
    }

    private void CloseOptionPanel()
    {
        rectTr.localScale = Vector3.zero;
    }
}
