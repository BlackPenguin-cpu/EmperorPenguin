using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Jobbutton : ItemCard
{
    bool isButtonClick;
    float clickDuration;
    float IconomeStack;

    [Header("���� ����")]
    public int penguinidx;
    public bool isBuy;
    [SerializeField] int buyincrementMoney;
    [Space(10)]
    [Header("������ ����")]
    public int level;
    [SerializeField] int maxLevel;
    [SerializeField] int firstLevelUpMoney;
    [SerializeField] int levelUpMoney;
    [SerializeField] int incrementMoney;

    private TextMeshProUGUI LevelText;
    protected override void Start()
    {
        base.Start();
        LevelText = gameObject.transform.Find("Level").GetComponent<TextMeshProUGUI>();
        if (isBuy == false)
        {
            buttonText.text = "����" + "\n" + $"({GetThousandCommaText(buyMoney)})";
            buttonText.text = "����ϱ�" + "\n" + $"({GetThousandCommaText(buyMoney)})";
            desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(buyincrementMoney + incrementMoney * level)}";
        }
        else
        {
            if (level == maxLevel)
            {
                buttonText.text = "�ִ� ����";
                desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(buyincrementMoney + incrementMoney * level)}";
                LevelText.text = $"Lv.Max";
            }
            else
            {
            buttonText.text = "������" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + levelUpMoney * level)})";
            desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(buyincrementMoney + incrementMoney * level)} -> {GetThousandCommaText(buyincrementMoney + incrementMoney * (level + 1))}";
            LevelText.text = $"Lv.{level}";
            }
            for (int i = 0; i < 10; i++)
            {
                if (GameObject.Find("BackGroundPenguin").transform.GetChild(i).GetComponent<Penguin>().penguinidx == penguinidx)
                    GameObject.Find("BackGroundPenguin").transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    protected override void Action()
    {
        if (GameManager.Instance.Coin >= buyMoney && isBuy == false)
        {
            for (int i = 0; i < 9; i++)
            {
                if (GameObject.Find("BackGroundPenguin").transform.GetChild(i).GetComponent<Penguin>().penguinidx == penguinidx)
                    GameObject.Find("BackGroundPenguin").transform.GetChild(i).gameObject.SetActive(true);
            }

            GameManager.Instance.Coin -= buyMoney;
            GameManager.Instance.secCoinup += buyincrementMoney;
            isBuy = true;
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
            level++;
            desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(buyincrementMoney + incrementMoney)} -> {GetThousandCommaText(buyincrementMoney + incrementMoney * (level + 1))}";
            buttonText.text = "������" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + levelUpMoney * level)})";
        }
        else if (GameManager.Instance.Coin >= firstLevelUpMoney + levelUpMoney * level && level != maxLevel)
        {
                GameManager.Instance.Coin -= firstLevelUpMoney + levelUpMoney * level;
                GameManager.Instance.secCoinup += incrementMoney;
                level++;
                if (level == maxLevel)
                {
                    buttonText.text = "�ִ� ����";
                    desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(buyincrementMoney + incrementMoney * level)}";
                    LevelText.text = $"Lv.Max";
                }
                else
                {

                buttonText.text = "������" + "\n" + $"({GetThousandCommaText(firstLevelUpMoney + levelUpMoney * level)})";
                desc.text = "�ʴ� ŉ�� ���" + "\n" + $"{GetThousandCommaText(buyincrementMoney + incrementMoney*level)} -> {GetThousandCommaText(buyincrementMoney + incrementMoney * (level + 1))}";
                LevelText.text = $"Lv.{level}";
                }
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
        }
        else if (GameManager.Instance.Coin <= firstLevelUpMoney + levelUpMoney * level || GameManager.Instance.Coin <= buyMoney)
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }
    private void Update()
    {
        if (isButtonClick) clickDuration += Time.deltaTime;
        if (isButtonClick && clickDuration > 1)
        {
            for (int i = 0; i < IconomeStack; i++)
                Action();
            clickDuration -= 0.01f;
            IconomeStack += 0.2f;
        }
    }

    public void ButtonClick()
    {
        isButtonClick = true;
    }
    public void ButtonClickUp()
    {
        isButtonClick = false;
        clickDuration = 0;
        IconomeStack = 0;
    }
    public string GetThousandCommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
