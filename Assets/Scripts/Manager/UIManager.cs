using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameObject[] shopPage;
    [SerializeField] Sprite on, off;
    private bool uiOn;
    public bool sulJungOn;
    [SerializeField] GameObject soundManager2;
    [SerializeField] GameObject soundManagerScreen;
    [SerializeField] GameObject leaderUI;

    private GameObject uiOnOff, UiButton, sulJungButton;
    void Start()
    {
        uiOnOff = ui.transform.Find("UIONOFF").gameObject;
        UiButton =ui.transform.Find("UiButtongrid").gameObject;
        sulJungButton= ui.transform.Find("SulJungButton").gameObject;
    }

    public void OnOffUI()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        if (uiOn == false)
        {
            uiOnOff.GetComponent<Image>().sprite = on;
            UiButton.transform.DOLocalMove(new Vector3(-489, -371, 0), 0.3f).SetEase(Ease.OutCirc);
            sulJungButton.transform.DOLocalMove(new Vector3(870, 350, 0), 0.3f).SetEase(Ease.OutCirc);
            leaderUI.transform.DOLocalMove(new Vector3(-1700, -410, 0), 0.3f).SetEase(Ease.OutCirc);
            uiOn = true;
        }
        else
        {
            uiOnOff.GetComponent<Image>().sprite = off;
            UiButton.transform.DOLocalMove(new Vector3(-489, -600, 0), 0.3f).SetEase(Ease.OutCirc);
            sulJungButton.transform.DOLocalMove(new Vector3(870, 670, 0), 0.3f).SetEase(Ease.OutCirc);
            leaderUI.transform.DOLocalMove(new Vector3(-1700, -410, 0), 0.3f).SetEase(Ease.OutCirc);
            uiOn = false;
        }
    }
    public void LeaderPenguin()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        leaderUI.transform.DOLocalMove(new Vector3(-445,-410,0),0.3f).SetEase(Ease.OutCirc);
            UiButton.transform.DOLocalMove(new Vector3(-489, -600, 0), 0.3f).SetEase(Ease.OutCirc);
            uiOnOff.GetComponent<Image>().sprite = on;
            uiOn = true;
        
    }
    public void LeaderPenguinOff()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        leaderUI.transform.DOLocalMove(new Vector3(-1700, -410, 0), 0.3f).SetEase(Ease.OutCirc);
            UiButton.transform.DOLocalMove(new Vector3(-489, -371, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void employee()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        shopPage[0].transform.DOLocalMove(new Vector3(0,0,0),0.3f).SetEase(Ease.OutCirc);
    }
    public void Jasan()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        shopPage[1].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void Realestate()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        shopPage[2].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void Jusik()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        shopPage[3].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void ExitShopPage()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        for (int i =0;i<4;i++)
        {
            shopPage[i].transform.DOLocalMove(new Vector3(0, -1000, 0), 0.3f).SetEase(Ease.OutCirc);
        }
    }
    public void SulJung()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        if (sulJungOn == false)
        {
            soundManager2.transform.DOScale(Vector3.one,0.3f);
            soundManagerScreen.transform.DOScale(Vector3.one, 0.3f);
            sulJungOn = true;
        }
        else
        {
            soundManager2.transform.transform.DOScale(Vector3.zero, 0.3f);
            soundManagerScreen.transform.transform.DOScale(Vector3.zero, 0.3f);
            sulJungOn = false;
        }
    }
}
