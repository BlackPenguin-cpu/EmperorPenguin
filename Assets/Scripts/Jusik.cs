using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[System.Serializable]
class range
{
    public float min;
    public float max;
}
public class Jusik : MonoBehaviour
{
    float curTime = 60;
    [SerializeField] float resetTime = 60;
    public int Count;
    public long nowValue;
    [SerializeField] range upValue;
    [SerializeField] range downValue;
    [SerializeField] float upChance;

    public Sprite IconImage;
    public string ItemName;
    string Description;

    TextMeshProUGUI desc;
    [SerializeField] TextMeshProUGUI ValueChange;

    float clickDuration;
    bool isBuyClicking;
    bool isSellClicking;
    private void Update()
    {
        curTime += Time.deltaTime;
        if (isBuyClicking || isSellClicking)
        {
            clickDuration += Time.deltaTime;
        }
        if (isSellClicking && clickDuration > 1)
        {
            SellAction();
            clickDuration -= 0.01f;
        }
        if (isBuyClicking && clickDuration > 1)
        {
            BuyAction();
            clickDuration -= 0.01f;
        }
        desc.text = $"{GetThousandCommaText(nowValue)}원 \n {Count}주 소유";
        if (curTime >= resetTime)
            JusikVariance();
    }
    void JusikVariance()
    {
        curTime = 0;
        long Value = nowValue;
        if (Random.Range(0, 100) < upChance)
            nowValue += (int)(nowValue * (Random.Range(upValue.min, upValue.max) / 100));
        else
            nowValue -= (int)(nowValue * (Random.Range(downValue.min, downValue.max) / 100));

        long changeValue = Value - nowValue;

        if (changeValue > 0)
        {
            ValueChange.color = Color.blue;
            ValueChange.text = "▼" + GetThousandCommaText(changeValue);
        }
        else if (changeValue < 0)
        {
            ValueChange.color = Color.red;
            ValueChange.text = "▲" + GetThousandCommaText(changeValue);
        }
    }
    void Start()
    {
        Image image = gameObject.transform.Find("Icon").GetComponent<Image>();
        image.sprite = IconImage;

        TextMeshProUGUI Name = gameObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        Name.text = ItemName;

        desc = gameObject.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        desc.text = Description;

        Button Buybutton = gameObject.transform.Find("BuyButton").GetComponent<Button>();
        Buybutton.onClick.AddListener(() => BuyAction());

        Button SellButton = gameObject.transform.Find("SellButton").GetComponent<Button>();
        SellButton.onClick.AddListener(() => SellAction());
    }

    void BuyAction()
    {
        if (nowValue <= GameManager.Instance.Coin)
        {
            GameManager.Instance.Coin -= nowValue;
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
            Count++;
        }
        else
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }
    void SellAction()
    {
        if (Count >= 1)
        {
            Count--;
            GameManager.Instance.Coin += nowValue;
            SoundManager.Instance.PlaySound("Buy", SoundType.SE, 1, 1);
        }
        else
        {
            SoundManager.Instance.PlaySound("Don_t_Buy", SoundType.SE, 1, 1);
        }
    }
    public string GetThousandCommaText(long data)
    {
        data = (long)Mathf.Abs(data);
        if (data == 0) return "0";
        return string.Format("{0:#,###}", data);
    }
    public void BuyCliking()
    {
        isBuyClicking = true;

    }
    public void SellCliking()
    {
        isSellClicking = true;

    }
    public void ClickUp()
    {
        isBuyClicking = false;
        isSellClicking = false;
        clickDuration = 0;
    }
}
