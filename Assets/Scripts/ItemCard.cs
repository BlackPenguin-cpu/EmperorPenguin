using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ItemCard : MonoBehaviour
{
    public Sprite IconImage;
    public string ItemName;
    public string Description;
    public string ButtonText;

    public int BuyMoney;
    protected virtual void Start()
    {
        Image image = gameObject.transform.Find("Icon").GetComponent<Image>();
        image.sprite = IconImage;

        TextMeshProUGUI Name = gameObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        Name.text = ItemName;

        TextMeshProUGUI desc = gameObject.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        desc.text = Description;

        Button button = gameObject.transform.Find("Button").GetComponent<Button>();
        button.onClick.AddListener(() => Action());

        TextMeshProUGUI buttonText = button.gameObject.transform.Find("ButtonText").GetComponent<TextMeshProUGUI>();
        buttonText.text = ButtonText;
    }
    protected abstract void Action();
}
