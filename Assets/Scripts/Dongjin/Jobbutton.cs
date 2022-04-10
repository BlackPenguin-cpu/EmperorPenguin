using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Jobbutton : ItemCard
{
    [Header("���� ����")]
    public int Penguinidx;
    public bool Buy;
    [SerializeField] int BuyincrementMoney;
    [Space(10)]
    [Header("������ ����")]
    public int Level;
    [SerializeField] int MaxLevel;
    [SerializeField] int firstLevelUpMoney;
    [SerializeField] int LevelUpMoney;
    [SerializeField] int incrementMoney;

    private TextMeshProUGUI LevelText;
    protected override void Start()
    {
        base.Start();
        LevelText = gameObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        if (Buy == false)
        {
            buttonText.text = "����" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
            buttonText.text = "����ϱ�" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
            desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)}";
        }
        else
        {
            buttonText.text = "������" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + LevelUpMoney * Level)})";
            desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)} -> {GetThousandCommaText(BuyincrementMoney + incrementMoney * (Level + 1))}";
            LevelText.text = $"Lv.{Level}";
            for (int i = 0; i < 4; i++)
            {
                if (GameObject.Find("Penguins").transform.GetChild(i).GetComponent<Penguin>().Penguinidx == Penguinidx)
                    GameObject.Find("Penguins").transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= BuyMoney && Buy == false)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GameObject.Find("Penguins").transform.GetChild(i).GetComponent<Penguin>().Penguinidx == Penguinidx)
                    GameObject.Find("Penguins").transform.GetChild(i).gameObject.SetActive(true);
            }

            GameManager.Instance.Coin -= BuyMoney;
            GameManager.Instance.secCoinup += BuyincrementMoney;
            Buy = true;
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
            Level++;
            buttonText.text = "������" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + LevelUpMoney * Level)})";
            desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)} -> {GetThousandCommaText(BuyincrementMoney + incrementMoney * (Level + 1))}";
        }
        else if (GameManager.Instance.Coin >= firstLevelUpMoney + LevelUpMoney * Level && Level != MaxLevel)
        {
                GameManager.Instance.Coin -= firstLevelUpMoney + LevelUpMoney * Level;
                GameManager.Instance.secCoinup += incrementMoney * Level;
                Level++;
                if (Level == MaxLevel)
                {
                    buttonText.text = "�ִ� ����";
                    desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)}";
                    LevelText.text = $"Lv.Max";
                }
                else
                {

                buttonText.text = "������" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + LevelUpMoney * Level)})";
                desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)} -> {GetThousandCommaText(BuyincrementMoney + incrementMoney * (Level + 1))}";
                LevelText.text = $"Lv.{Level}";
                }
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
        }
        else if (GameManager.Instance.Coin <= firstLevelUpMoney + LevelUpMoney * Level || GameManager.Instance.Coin <= BuyMoney)
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
