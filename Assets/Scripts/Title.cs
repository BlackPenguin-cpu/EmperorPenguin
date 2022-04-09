using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] Text ClicktoStart;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ClicktoStart.color = new Color(0, 0, 0, Mathf.Abs(Mathf.Cos(Time.time)));
    }
}
