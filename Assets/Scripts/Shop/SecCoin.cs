using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SecCoin : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        textMeshProUGUI.text = "√ ¥Á    : " + GetThousandCommaText(GameManager.Instance.secCoinup);
    }
    public string GetThousandCommaText(long data)
    {
        if (data == 0) return "0";
        return string.Format("{0:#,###}", data);
    }
}
