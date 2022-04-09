using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickManager : MonoBehaviour
{
    [Header("Coin Info")]
    public int Coin;
    public int ClickValue;
    public float CoinUp;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) ClickAction();
    }
    public void ClickAction()
    {
        Coin += ClickValue;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        var obj = Instantiate(Resources.Load<GameObject>("Coin"), pos, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-2, 2), CoinUp, 0), ForceMode2D.Impulse);
        obj.GetComponent<SpriteRenderer>().DOFade(0, 1);
        Destroy(obj, 2);
    }
}
