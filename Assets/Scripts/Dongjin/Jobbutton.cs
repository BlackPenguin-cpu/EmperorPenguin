using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Jobbutton : ItemCard
{
    [Header("���� ����")]
    [SerializeField] int Penguinidx;
    [SerializeField] bool Buy;
    [SerializeField] int BuyincrementMoney;
    [Space(10)]
    [Header("������ ����")]
    [SerializeField] int Level;
    [SerializeField] int MaxLevel;
    [SerializeField] int firstLevelUpMoney;
    [SerializeField] int LevelUpMoney;
    [SerializeField] int incrementMoney;

    private TextMeshProUGUI LevelText;
    protected override void Start()
    {
        base.Start();
        buttonText.text = "����" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
        LevelText = gameObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        buttonText.text = "����ϱ�" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
        desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)}";
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= BuyMoney && Buy == false)
        {
            GameObject.Find("Penguins").transform.GetChild(Penguinidx).gameObject.SetActive(true);

            GameManager.Instance.Coin -= BuyMoney;
            /*GameManager.Instance.ClickCoinUp += BuyincrementMoney;*/
            GameManager.Instance.secCoinup += BuyincrementMoney;
            Buy = true;

            buttonText.text = "������" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + LevelUpMoney * Level)})";
            desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)} -> {GetThousandCommaText(BuyincrementMoney + incrementMoney * (Level + 1))}";
        }
        else if (GameManager.Instance.Coin >= BuyincrementMoney + incrementMoney * Level && Level != MaxLevel)
        {
            GameManager.Instance.Coin -= firstLevelUpMoney + LevelUpMoney * Level;
            /*GameManager.Instance.ClickCoinUp += firstincrementMoney +incrementMoney* Level;*/
            GameManager.Instance.secCoinup += BuyincrementMoney + incrementMoney * Level;
            Level++;

            buttonText.text = "������" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + LevelUpMoney * Level)})";
            desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)} -> {GetThousandCommaText(BuyincrementMoney + incrementMoney * (Level + 1))}";
            LevelText.text = $"Lv.{Level}";
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
