using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JasanText : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        text.text = "�ڻ� : " + GetThousandCommaText(GameManager.Instance.Coin) + "\\";
    }
    public string GetThousandCommaText(long data)
    {
        if (data == 0) return "0";
        return string.Format("{0:#,###}", data);
    }
}
