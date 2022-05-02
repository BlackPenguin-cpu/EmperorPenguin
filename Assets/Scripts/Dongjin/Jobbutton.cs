using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Jobbutton : ItemCard
{
    bool buttonClick;
    float clickDuration;
    float IconomeStack;

    [Header("±¸¸Å Á¤º¸")]
    public int Penguinidx;
    public bool Buy;
    [SerializeField] int BuyincrementMoney;
    [Space(10)]
    [Header("·¹º§¾÷ Á¤º¸")]
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
            buttonText.text = "±¸¸Å" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
            buttonText.text = "°í¿ëÇÏ±â" + "\n" + $"({GetThousandCommaText(BuyMoney)})";
            desc.text = "ÃÊ´ç Å‰µæ °ñµå" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)}";
        }
        else
        {
            if (Level == MaxLevel)
            {
                buttonText.text = "ÃÖ´ë ·¹º§";
                desc.text = "ÃÊ´ç Å‰µæ °ñµå" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)}";
                LevelText.text = $"Lv.Max";
            }
            else
            {
            buttonText.text = "·¹º§¾÷" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + LevelUpMoney * Level)})";
            desc.text = "ÃÊ´ç Å‰µæ °ñµå" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)} -> {GetThousandCommaText(BuyincrementMoney + incrementMoney * (Level + 1))}";
            LevelText.text = $"Lv.{Level}";
            }
            for (int i = 0; i < 10; i++)
            {
                if (GameObject.Find("BackGroundPenguin").transform.GetChild(i).GetComponent<Penguin>().Penguinidx == Penguinidx)
                    GameObject.Find("BackGroundPenguin").transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= BuyMoney && Buy == false)
        {
            for (int i = 0; i < 9; i++)
            {
                if (GameObject.Find("BackGroundPenguin").transform.GetChild(i).GetComponent<Penguin>().Penguinidx == Penguinidx)
                    GameObject.Find("BackGroundPenguin").transform.GetChild(i).gameObject.SetActive(true);
            }

            GameManager.Instance.Coin -= BuyMoney;
            GameManager.Instance.secCoinup += BuyincrementMoney;
            Buy = true;
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
            Level++;
            desc.text = "ÃÊ´ç Å‰µæ °ñµå" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney)} -> {GetThousandCommaText(BuyincrementMoney + incrementMoney * (Level + 1))}";
            buttonText.text = "·¹º§¾÷" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + LevelUpMoney * Level)})";
        }
        else if (GameManager.Instance.Coin >= firstLevelUpMoney + LevelUpMoney * Level && Level != MaxLevel)
        {
                GameManager.Instance.Coin -= firstLevelUpMoney + LevelUpMoney * Level;
                GameManager.Instance.secCoinup += incrementMoney;
                Level++;
                if (Level == MaxLevel)
                {
                    buttonText.text = "ÃÖ´ë ·¹º§";
                    desc.text = "ÃÊ´ç Å‰µæ °ñµå" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney * Level)}";
                    LevelText.text = $"Lv.Max";
                }
                else
                {

                buttonText.text = "·¹º§¾÷" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + LevelUpMoney * Level)})";
                desc.text = "ÃÊ´ç Å‰µæ °ñµå" + "\n" + $"{GetThousandCommaText(BuyincrementMoney + incrementMoney*Level)} -> {GetThousandCommaText(BuyincrementMoney + incrementMoney * (Level + 1))}";
                LevelText.text = $"Lv.{Level}";
                }
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
        }
        else if (GameManager.Instance.Coin <= firstLevelUpMoney + LevelUpMoney * Level || GameManager.Instance.Coin <= BuyMoney)
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }
    private void Update()
    {
        if (buttonClick) clickDuration += Time.deltaTime;
        if (buttonClick && clickDuration > 1)
        {
            for (int i = 0; i < IconomeStack; i++)
                Action();
            clickDuration -= 0.01f;
            IconomeStack += 0.2f;
        }
    }

    public void ButtonClick()
    {
        buttonClick = true;
    }
    public void ButtonClickUp()
    {
        buttonClick = false;
        clickDuration = 0;
        IconomeStack = 0;
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
