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
    public int Level;
    [SerializeField] int firstLevelUpMoney;
    [SerializeField] int LevelUpMoney;
    [SerializeField] int incrementMoney;

    private TextMeshProUGUI LevelText;
    protected override void Start()
    {
        base.Start();
        LevelText = gameObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        LevelText.text = $"Lv.{Level + 1}";
        buttonText.text = $"{firstLevelUpMoney + LevelUpMoney * Level}��";
        desc.text = "Ŭ�� �� ���" + "\n" + $"{GetThousandCommaText(firstincrementMoney + incrementMoney * Level)}";
        GameManager.Instance.ClickCoinUp += firstincrementMoney + incrementMoney * Level;
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= firstLevelUpMoney + LevelUpMoney * Level)
        {
            GameManager.Instance.Coin -= firstLevelUpMoney + LevelUpMoney * Level;
            GameManager.Instance.ClickCoinUp = firstincrementMoney + incrementMoney * Level;
            Level++;
            LevelText.text = $"Lv.{Level}";
            buttonText.text = $"{firstLevelUpMoney + LevelUpMoney * Level}��";
            desc.text = "Ŭ�� �� ���" + "\n" + $"{GetThousandCommaText(firstincrementMoney + incrementMoney * Level)}";
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
        }
        else
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
