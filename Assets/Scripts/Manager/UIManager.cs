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
    [SerializeField] GameObject SoundManager;
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
            LeaderUI.transform.DOLocalMove(new Vector3(-445,-410,0),0.3f).SetEase(Ease.OutCirc);
            UiButton.transform.DOLocalMove(new Vector3(-489, -600, 0), 0.3f).SetEase(Ease.OutCirc);
            UIONOFF.GetComponent<Image>().sprite = On;
            UIOn = true;
        
    }
    public void LeaderPenguinOff()
    {
            LeaderUI.transform.DOLocalMove(new Vector3(-1700, -410, 0), 0.3f).SetEase(Ease.OutCirc);
            UiButton.transform.DOLocalMove(new Vector3(-489, -371, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void employee()
    {
        ShopPage[0].transform.DOLocalMove(new Vector3(0,0,0),0.3f).SetEase(Ease.OutCirc);
    }
    public void Jasan()
    {
        ShopPage[1].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void Realestate()
    {
        ShopPage[2].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void Jusik()
    {
        ShopPage[3].transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutCirc);
    }
    public void ExitShopPage()
    {
        for(int i =0;i<4;i++)
        {
            ShopPage[i].transform.DOLocalMove(new Vector3(0, -1000, 0), 0.3f).SetEase(Ease.OutCirc);
        }
    }
    public void SulJung()
    {
        if(SulJungOn == false)
        {
            SoundManager.transform.GetChild(0).GetChild(0).transform.DOScale(Vector3.one,0.3f);
            SulJungOn = true;
        }
        else
        {
            SoundManager.transform.GetChild(0).GetChild(0).transform.DOScale(Vector3.zero, 0.3f);
            SulJungOn = false;
        }
    }
}
