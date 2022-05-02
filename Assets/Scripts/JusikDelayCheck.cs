using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JusikDelayCheck : MonoBehaviour
{
    TextMeshProUGUI delayTimeText;
    Jusik jusik;
    string str;
    void Start()
    {
        delayTimeText = GetComponent<TextMeshProUGUI>();
        jusik = FindObjectOfType<Jusik>();
    }

    void Update()
    {
        if ((int)jusik.curTime == 0)
            str = "주식 갱신까지 남은시간: 01 : 00";
        else
            str = "주식 갱신까지 남은시간: 00 : " + (60 - (int)jusik.curTime);
        delayTimeText.text = str;
    }
}