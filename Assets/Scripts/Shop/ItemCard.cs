using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ItemCard : MonoBehaviour 
{
    public Sprite iconImage;
    public string itemName;
    protected string description;
    protected string buttonTextString;

    protected TextMeshProUGUI desc;
    protected TextMeshProUGUI buttonText;

    public long buyMoney;
    protected virtual void Start()
    {
        Image image = gameObject.transform.Find("Icon").GetComponent<Image>();
        image.sprite = iconImage;

        TextMeshProUGUI Name = gameObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        Name.text = itemName;

        desc = gameObject.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        desc.text = description;

        Button button = gameObject.transform.Find("Button").GetComponent<Button>();
        button.onClick.AddListener(() => Action());

        buttonText = button.gameObject.transform.Find("ButtonText").GetComponent<TextMeshProUGUI>();
        buttonText.text = buttonTextString;
    }
    protected abstract void Action();

}
