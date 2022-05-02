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
    [SerializeField] int firstLevelUpMoney;
    [SerializeField] int LevelUpMoney;
    [SerializeField] int incrementMoney;

    private TextMeshProUGUI LevelText;

    float clickDuration;
    bool isClicking;
    float IconomeStack = 1;
    protected override void Start()
    {
        base.Start();
        if (Level == 0)
        {
            Level = 1;
            GameManager.Instance.ClickCoinUp = firstincrementMoney;
        }
        LevelText = gameObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        LevelText.text = $"Lv.{Level}";
        buttonText.text = $"{firstincrementMoney + incrementMoney * Level}원";
        desc.text = "클릭 당 골드" + "\n" + $"{firstincrementMoney + incrementMoney * Level}";
        //GameManager.Instance.ClickCoinUp += firstincrementMoney + incrementMoney * Level;
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= firstLevelUpMoney + LevelUpMoney * (Level - 1))
        {
            GameManager.Instance.Coin -= firstLevelUpMoney + LevelUpMoney * (Level - 1);
            GameManager.Instance.ClickCoinUp = firstincrementMoney + incrementMoney * Level;
            Level++;
            LevelText.text = $"Lv.{Level}";
            buttonText.text = $"{firstLevelUpMoney + LevelUpMoney * (Level - 1)}원";
            desc.text = "클릭 당 골드" + "\n" + $"{GetThousandCommaText(firstincrementMoney + incrementMoney * Level)}";
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
        }
        else
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }

    private void Update()
    {
        if (isClicking)
        {
            clickDuration += Time.deltaTime;
            if (clickDuration > 1)
            {
                for (int i = 0; i < IconomeStack; i++)
                    Action();
                clickDuration -= 0.01f;
                IconomeStack += 0.2f;
            }
        }
    }
    public void onClick()
    {
        isClicking = true;
    }
    public void onClickUp()
    {
        isClicking = false;
        IconomeStack = 1;
        clickDuration = 0;
    }

    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
