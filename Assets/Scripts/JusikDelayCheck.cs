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
            str = "�ֽ� ���ű��� �����ð�: 01 : 00";
        else
            str = "�ֽ� ���ű��� �����ð�: 00 : " + (60 - (int)jusik.curTime);
        delayTimeText.text = str;
    }
}