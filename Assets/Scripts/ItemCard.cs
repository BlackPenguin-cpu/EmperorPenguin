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

    bool Clicking;
    TextMeshProUGUI buttonText;
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

        buttonText = button.gameObject.transform.Find("ButtonText").GetComponent<TextMeshProUGUI>();
        buttonText.text = ButtonText;


        button.onClick.AddListener(() => { buttonText.transform.localPosition -= new Vector3(0, -10); Clicking = true; });
    }
    protected virtual void Update()
    {
        if (Clicking)
        {
            if (Input.GetMouseButtonUp(0))
            {
                buttonText.transform.localPosition += new Vector3(0, 10);
                Clicking = false;
            }
        }
    }
    protected abstract void Action();
}
