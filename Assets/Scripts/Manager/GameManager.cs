using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Coin Info")]
    public long Coin;
    public long ClickCoinUp;
    public long secCoinup;
    public float CoinBouce;
    float Coolodwn;
    private void Start()
    {
        SoundManager.Instance.PlaySound("Ingame", SoundType.BGM, 1, 1);
    }
    private void Update()
    {
        Coolodwn += Time.deltaTime;
        if(Coolodwn >= 1)
        {
            Coolodwn = 0;
            Coin += secCoinup;
        }
    }

    public void ClickAction()
    {
        Coin += ClickCoinUp;
        SoundManager.Instance.PlaySound("Coin",SoundType.SE, 1, 1);
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        var obj = Instantiate(Resources.Load<GameObject>("Coin"), pos, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-2, 2), CoinBouce, 0), ForceMode2D.Impulse);
        obj.GetComponent<SpriteRenderer>().DOFade(0, 1);
        Destroy(obj, 2);
    }
}
