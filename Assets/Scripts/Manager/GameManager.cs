using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Coin Info")]
    public int Coin;
    public int ClickValue;
    public int secCoinup; 
    public float CoinUp;

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
