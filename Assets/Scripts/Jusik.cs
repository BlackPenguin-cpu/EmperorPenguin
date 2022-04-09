using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class range
{
    public float min;
    public float max;
}
public class Jusik : MonoBehaviour
{
    float curTime;
    [SerializeField] string Name;
    [SerializeField] float nowValue;
    [SerializeField] range upValue;
    [SerializeField] range downValue;
    [SerializeField] float upChance;


    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 60)
            Action();
    }
    protected void Action()
    {
        if (Random.Range(0, 100) < upChance)
            nowValue += nowValue * (Random.Range(upValue.min, upValue.max) / 100);
        else
            nowValue -= nowValue * (Random.Range(downValue.min, downValue.max) / 100);

    }
}
