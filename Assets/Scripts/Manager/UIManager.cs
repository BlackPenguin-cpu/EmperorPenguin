using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject[] ShopPage;
    [SerializeField] Sprite On, Off;
    private bool UIOn;
    public bool SulJungOn;
    [SerializeField] GameObject SoundManager2;
    [SerializeField] GameObject soundManagerScreen;
    [SerializeField] GameObject LeaderUI;

    private GameObject UIONOFF, UiButton, SulJungButton;
    void Start()
    {
        UIONOFF = UI.transform.Find("UIONOFF").gameObject;
        UiButton =UI.transform.Find("UiButtongrid").gameObject;
        SulJungButton= UI.transform.Find("SulJungButton").gameObject;
    }

    public void OnOffUI()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        if (UIOn == false)
        {
            UIONOFF.GetComponent<Image>().sprite = On;
            UiButton.transform.DOLocalMove(new Vector3(-489, -371, 0), 0.3f).SetEase(Ease.OutCirc);
            SulJungButton.transform.DOLocalMove(new Vector3(870, 350, 0), 0.3f).SetEase(Ease.OutCirc);
            LeaderUI.transform.DOLocalMove(new Vector3(-1700, -410, 0), 0.3f).SetEase(Ease.OutCirc);
            UIOn = true;
        }
        else
        {
            UIONOFF.GetComponent<Image>().sprite = Off;
            UiButton.transform.DOLocalMove(new Vector3(-489, -600, 0), 0.3f).SetEase(Ease.OutCirc);
            SulJungButton.transform.DOLocalMove(new Vector3(870, 670, 0), 0.3f).SetEase(Ease.OutCirc);
            LeaderUI.transform.DOLocalMove(new Vector3(-1700, -410, 0), 0.3f).SetEase(Ease.OutCirc);
            UIOn = false;
        }
    }
    public void LeaderPenguin()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        LeaderUI.transform.DOLocalMove(new Vector3(-445,-410,0),0.3f).SetEase(Ease.OutCirc);
            UiButton.transform.DOLocalMove(new Vector3(-489, -600, 0), 0.3f).SetEase(Ease.OutCirc);
            UIONOFF.GetComponent<Image>().sprite = On;
            UIOn = true;
        
    }
    public void LeaderPenguinOff()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        LeaderUI.transform.DOLocalMove(new Vector3(-1700, -410, 0), 0.3f).SetEase(Ease.OutCirc);
            UiButton.transform.DOLocalMove(new Vector3(-489, -371, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void employee()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        ShopPage[0].transform.DOLocalMove(new Vector3(0,0,0),0.3f).SetEase(Ease.OutCirc);
    }
    public void Jasan()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        ShopPage[1].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void Realestate()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        ShopPage[2].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void Jusik()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        ShopPage[3].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void ExitShopPage()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        for (int i =0;i<4;i++)
        {
            ShopPage[i].transform.DOLocalMove(new Vector3(0, -1000, 0), 0.3f).SetEase(Ease.OutCirc);
        }
    }
    public void SulJung()
    {
        SoundManager.Instance.PlaySound("Button_Click", SoundType.SE, 1, 1);
        if (SulJungOn == false)
        {
            SoundManager2.transform.DOScale(Vector3.one,0.3f);
            soundManagerScreen.transform.DOScale(Vector3.one, 0.3f);
            SulJungOn = true;
        }
        else
        {
            SoundManager2.transform.transform.DOScale(Vector3.zero, 0.3f);
            soundManagerScreen.transform.transform.DOScale(Vector3.zero, 0.3f);
            SulJungOn = false;
        }
    }
}
