using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Jobbutton : ItemCard
{
    [Header("구매 정보")]
    [SerializeField] int Panguinidx;
    [SerializeField] bool Buy;
    [SerializeField] protected Sprite _IconImage;
    [SerializeField] protected string _ItemName;
    [SerializeField] protected string _Description;
    [SerializeField] protected string _ButtonText;
    [SerializeField] int BuyincrementMoney;


    [Space(10)]
    [Header("레벨업 정보")]
    [SerializeField] int Level;
    [SerializeField] int MaxLevel;
    [SerializeField] int LevelUpMoney;
    [SerializeField] int incrementMoney;

    private Text buttontext2;
    private void Awake()
    {
        IconImage =_IconImage;
        ItemName = _ItemName;
        Description = _Description;
        ButtonText = _ButtonText;
    }
    protected override void Start()
    {
        base.Start();
        buttontext2 = gameObject.transform.Find("Button").Find("ButtonText2").GetComponent<Text>();
        buttontext2.text = $"({BuyMoney})";
    }
    protected override void Action()
    {
        if(GameManager.Instance.Coin >= BuyMoney&&Buy== false)
        {
            GameManager.Instance.Coin -= BuyMoney;
            GameObject.Find("Panguins").transform.GetChild(Panguinidx).gameObject.SetActive(true);
            GameManager.Instance.ClickCoinUp += BuyincrementMoney;
            Text buttontext = gameObject.transform.Find("Button").Find("ButtonText").GetComponent<Text>();
            buttontext.text = "레벨업";
            buttontext2.text = $"({LevelUpMoney + 1000 * Level})";
        }
        else if(GameManager.Instance.Coin >= BuyMoney)
        {
            GameManager.Instance.Coin -= LevelUpMoney + 1000 * Level;
            GameManager.Instance.ClickCoinUp += incrementMoney +incrementMoney* Level;
            Level++;
            buttontext2.text = $"({LevelUpMoney + 1000 * Level})";
        }
    }
}
