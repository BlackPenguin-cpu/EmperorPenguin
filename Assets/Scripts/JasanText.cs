using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JasanText : MonoBehaviour
{
    TextMeshProUGUI text;
    void Update()
    {
        text.text = "ÀÚ»ê :" + GetThousandCommaText(GameManager.Instance.Coin) + "\\";
    }
    public string GetThousandCommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }
}
