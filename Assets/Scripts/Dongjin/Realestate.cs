using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Realestate : ItemCard
{

    [Header("���� ����")]
    public bool Buy;
    [SerializeField] long incrementMoney;
    public long realMoney;
    private float timer;

    protected override void Start()
    {
        base.Start();
        if(Buy == true)
        {
            buttonText.text = "�Ǹ�";
        }
        else
        {
            desc.text = "����" + "\n" + buyMoney;
            buttonText.text = "����";
        }
    }
    private void Update()
    {
        if (Buy == true)
            timer += Time.deltaTime;
        desc.text = "����" + "\n" + GetThousandCommaText(realMoney) + $"(+{GetThousandCommaText(incrementMoney)}s)";
        realMoney = buyMoney + incrementMoney * (int)timer;
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= buyMoney && Buy == false)
        {
            GameManager.Instance.Coin -= buyMoney;
            buttonText.text = "�Ǹ�";
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
            Buy = true;
        }
        else if (Buy == true)
        {
            GameManager.Instance.Coin += realMoney;
            buttonText.text = "����";
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
            timer = 0;
            Buy = false;
        }
        else if(GameManager.Instance.Coin <= buyMoney)
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
