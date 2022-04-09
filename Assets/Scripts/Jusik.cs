using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
class range
{
    public float min;
    public float max;
}
public class Jusik : MonoBehaviour
{
    float curTime;
    public int Count;
    [SerializeField] int nowValue;
    [SerializeField] range upValue;
    [SerializeField] range downValue;
    [SerializeField] float upChance;

    public Sprite IconImage;
    public string ItemName;
    string Description;

    TextMeshProUGUI desc;
    private void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= 60)
            JusikVariance();
    }
    void JusikVariance()
    {
        if (Random.Range(0, 100) < upChance)
            nowValue += (int)(nowValue * (Random.Range(upValue.min, upValue.max) / 100));
        else
            nowValue -= (int)(nowValue * (Random.Range(downValue.min, downValue.max) / 100));
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
        if (nowValue >= GameManager.Instance.Coin)
        {
            GameManager.Instance.Coin -= nowValue;
            Count++;
        }
    }
    void SellAction()
    {
        if (Count >= 1)
        {
            Count--;
            GameManager.Instance.Coin -= nowValue;
        }
    }
}
