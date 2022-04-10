using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JaGum : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        textMeshProUGUI.text = "ÀÚ±Ý : " + GetThousandCommaText(GameManager.Instance.Coin) + "\\";
    }
    public string GetThousandCommaText(long data)
    {
        if (data == 0) return "0";
        return string.Format("{0:#,###}", data);
    }
}
