using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ItemCard : MonoBehaviour
{
    protected Sprite IconImage;
    protected string ItemName;
    protected string Description;
    protected string ButtonText;
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

        Text buttontext = button.gameObject.transform.Find("ButtonText").GetComponent<Text>();
        buttontext.text = ButtonText;
    }
    protected abstract void Action();
}
