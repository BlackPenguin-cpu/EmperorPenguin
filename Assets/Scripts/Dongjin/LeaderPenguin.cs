using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LeaderPenguin : ItemCard
{
    [Header("���� ����")]
    [SerializeField] int firstincrementMoney;
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
        LevelText = gameObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        LevelText.text = $"Lv.{Level + 1}";
        buttonText.text = $"{LevelUpMoney}��";
        desc.text = "Ŭ�� �� ���" + "\n" + $"{GetThousandCommaText(firstincrementMoney + incrementMoney * Level)}";
        GameManager.Instance.ClickCoinUp += firstincrementMoney;
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= firstincrementMoney + LevelUpMoney * Level && Level != MaxLevel)
        {
            Level++;
            GameManager.Instance.Coin -= firstLevelUpMoney + LevelUpMoney * Level;
            GameManager.Instance.ClickCoinUp+= firstincrementMoney + incrementMoney * Level;
            LevelText.text = $"���� �ر� Lv.{Level + 1}";
            buttonText.text = $"{firstLevelUpMoney + LevelUpMoney * Level}��";
            desc.text = "Ŭ�� �� ���" + "\n" + $"{GetThousandCommaText(firstincrementMoney + incrementMoney * Level)}";
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
