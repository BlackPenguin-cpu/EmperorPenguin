using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ItemCard : MonoBehaviour
{
    public Sprite IconImage;
    public string ItemName;
    protected string Description;
    protected string ButtonText;

    protected TextMeshProUGUI desc;
    protected TextMeshProUGUI buttonText;

    public long BuyMoney;
    protected virtual void Start()
    {
        Image image = gameObject.transform.Find("Icon").GetComponent<Image>();
        image.sprite = IconImage;

        TextMeshProUGUI Name = gameObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        Name.text = ItemName;

        desc = gameObject.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        desc.text = Description;

        Button button = gameObject.transform.Find("Button").GetComponent<Button>();
        button.onClick.AddListener(() => Action());

        buttonText = button.gameObject.transform.Find("ButtonText").GetComponent<TextMeshProUGUI>();
        buttonText.text = ButtonText;
    }
    protected abstract void Action();
}
