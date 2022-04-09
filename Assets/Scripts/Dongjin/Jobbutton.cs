using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jobbutton : MonoBehaviour
{
    [SerializeField] int Panguinidx;
    public void EmployButton()
    {
        GameObject.Find("Panguins").transform.GetChild(Panguinidx).gameObject.SetActive(true);
    }
}
