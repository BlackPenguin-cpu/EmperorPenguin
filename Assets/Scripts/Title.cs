using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public static Title Instance;
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField] Text ClicktoStart;
    void Update()
    {
        ClicktoStart.color = new Color(0, 0, 0, Mathf.Abs(Mathf.Cos(Time.time)));
    }
}
