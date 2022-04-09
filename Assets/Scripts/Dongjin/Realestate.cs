using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Realestate : ItemCard
{

    [Header("구매 정보")]
    [SerializeField] bool Buy;
    [SerializeField] int incrementMoney;
    private float timer;
    protected override void Start()
    {
        base.Start();
        desc.text = "가격" + "\n" + BuyMoney;
        buttonText.text = "구매";
    }
    private void Update()
    {
        if(Buy == true)
            timer += Time.deltaTime;
        desc.text = "가격" + "\n" + BuyMoney + incrementMoney * (int)timer;
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= BuyMoney && Buy == false)
        {
            GameManager.Instance.Coin -= BuyMoney;
            buttonText.text = "판매";
            Buy = true;
        }
        else
        {
            GameManager.Instance.Coin += BuyMoney + incrementMoney * (int)timer;
            buttonText.text = "구매";
            timer = 0;
            Buy = false;
        }
    }
    public string GetThousandCommaText(int data)
    {
        return string.Format("{0:#,###}", data);
    }
}
