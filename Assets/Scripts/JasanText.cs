using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JasanText : ItemCard
{
    [SerializeField] long SellMoney;
    [Header("±¸¸Å Á¤º¸")]
    public int Jasanidx;
    public bool Buy;
    [SerializeField] int secincrement,clickincrement;

    protected override void Start()
    {
        base.Start();
        buttonText.text = "±¸¸Å" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
        desc.text = $"ÃÊ´ç Å‰µæ °ñµå / Å¬¸¯ ´ç Å‰µæ °ñµå\n{secincrement}/{clickincrement}";
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= BuyMoney && Buy == false)
        {
            GameObject.Find("Jasans").transform.GetChild(Jasanidx).gameObject.SetActive(true);
            GameManager.Instance.Coin -= BuyMoney;
            GameManager.Instance.secCoinup += secincrement;
            GameManager.Instance.ClickCoinUp += clickincrement;
            buttonText.text = "ÆÇ¸Å" + "\n" + $"({GetThousandCommaText(SellMoney)})";
            Buy = true;
        }
        else if (Buy == true)
        {
            GameObject.Find("Jasans").transform.GetChild(Jasanidx).gameObject.SetActive(true);
            GameManager.Instance.Coin += SellMoney;
            GameManager.Instance.secCoinup -= secincrement;
            GameManager.Instance.ClickCoinUp -= clickincrement;
            buttonText.text = "±¸¸Å" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
            Buy = true;
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
