using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Realestate : ItemCard
{

    [Header("���� ����")]
    [SerializeField] bool Buy;
    [SerializeField] long incrementMoney;
    private float timer;
    protected override void Start()
    {
        base.Start();
        desc.text = "����" + "\n" + BuyMoney;
        buttonText.text = "����";
    }
    private void Update()
    {
        if (Buy == true)
            timer += Time.deltaTime;
        desc.text = "����" + "\n" + GetThousandCommaText(BuyMoney + incrementMoney * (int)timer) + $"(+{GetThousandCommaText(incrementMoney)}s)";
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= BuyMoney && Buy == false)
        {
            GameManager.Instance.Coin -= BuyMoney;
            buttonText.text = "�Ǹ�";
            Buy = true;
        }
        else if (Buy == true)
        {
            GameManager.Instance.Coin += BuyMoney + incrementMoney * (int)timer;
            buttonText.text = "����";
            timer = 0;
            Buy = false;
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
