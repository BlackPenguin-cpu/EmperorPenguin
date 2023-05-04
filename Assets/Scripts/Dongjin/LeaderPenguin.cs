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
    public int level;
    [SerializeField] int firstLevelUpMoney;
    [SerializeField] int levelUpMoney;
    [SerializeField] int incrementMoney;

    private TextMeshProUGUI levelText;

    float clickDuration;
    bool isClicking;
    float iconomeStack = 1;
    protected override void Start()
    {
        base.Start();
        if (level == 0)
        {
            level = 1;
            GameManager.Instance.ClickCoinUp = firstincrementMoney;
        }
        levelText = gameObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        levelText.text = $"Lv.{level}";
        buttonText.text = $"{firstincrementMoney + incrementMoney * level}원";
        desc.text = "클릭 당 골드" + "\n" + $"{firstincrementMoney + incrementMoney * level}";
        //GameManager.Instance.ClickCoinUp += firstincrementMoney + incrementMoney * Level;
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= firstLevelUpMoney + levelUpMoney * (level - 1))
        {
            GameManager.Instance.Coin -= firstLevelUpMoney + levelUpMoney * (level - 1);
            GameManager.Instance.ClickCoinUp = firstincrementMoney + incrementMoney * level;
            level++;
            levelText.text = $"Lv.{level}";
            buttonText.text = $"{firstLevelUpMoney + levelUpMoney * (level - 1)}원";
            desc.text = "클릭 당 골드" + "\n" + $"{GetThousandCommaText(firstincrementMoney + incrementMoney * level)}";
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
                for (int i = 0; i < iconomeStack; i++)
                    Action();
                clickDuration -= 0.01f;
                iconomeStack += 0.2f;
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
        iconomeStack = 1;
        clickDuration = 0;
    }

    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
