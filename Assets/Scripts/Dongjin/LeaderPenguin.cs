using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LeaderPenguin : ItemCard
{
    [Header("구매 정보")]
    [SerializeField] int firstincrementMoney;
    [Space(10)]
    [Header("레벨업 정보")]
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
        LevelText.text = $"Lv.{Level + 1}";
        buttonText.text = $"{firstLevelUpMoney + LevelUpMoney * Level}원";
        desc.text = "클릭 당 골드" + "\n" + $"{GetThousandCommaText(firstincrementMoney + incrementMoney * Level)}";
        GameManager.Instance.ClickCoinUp += firstincrementMoney + incrementMoney * Level;
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= firstLevelUpMoney + LevelUpMoney * Level && Level != MaxLevel)
        {
            GameManager.Instance.Coin -= firstLevelUpMoney + LevelUpMoney * Level;
            GameManager.Instance.ClickCoinUp+= firstincrementMoney + incrementMoney * Level;
            Level++;
            LevelText.text = $"Lv.{Level+1}";
            buttonText.text = $"{firstLevelUpMoney + LevelUpMoney * Level}원";
            desc.text = "클릭 당 골드" + "\n" + $"{GetThousandCommaText(firstincrementMoney + incrementMoney * Level)}";
        }
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
