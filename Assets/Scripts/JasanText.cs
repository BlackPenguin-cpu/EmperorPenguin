using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JasanText : ItemCard
{
    [SerializeField] long SellMoney;
    [Header("���� ����")]
    public int Jasanidx;
    public bool Buy;
    [SerializeField] int secincrement,clickincrement;

    protected override void Start()
    {
        base.Start();
        if(Buy == false)
        {
            buttonText.text = "����" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
            desc.text = $"�ʴ� ŉ�� ��� / Ŭ�� �� ŉ�� ���\n{secincrement}/{clickincrement}";
        }
        else
        {
            buttonText.text = "������";
            desc.text = $"�ʴ� ŉ�� ��� / Ŭ�� �� ŉ�� ���\n{secincrement}/{clickincrement}";
            GameObject.Find("Jasans").transform.GetChild(Jasanidx).gameObject.SetActive(true);
        }
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= BuyMoney && Buy == false)
        {
            GameObject.Find("Jasans").transform.GetChild(Jasanidx).gameObject.SetActive(true);
            GameManager.Instance.Coin -= BuyMoney;
            GameManager.Instance.secCoinup += secincrement;
            GameManager.Instance.ClickCoinUp += clickincrement;
            buttonText.text = "������";
            Buy = true;
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
        }
        else if (GameManager.Instance.Coin <= BuyMoney)
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
