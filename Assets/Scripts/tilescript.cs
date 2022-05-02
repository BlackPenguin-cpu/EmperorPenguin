using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class tilescript : MonoBehaviour
{
    [SerializeField] AudioSource titleAudio;

    [SerializeField] GameObject title, titletext;
    [SerializeField] GameObject CreatorUI;
    [SerializeField] GameObject CreatorButtons;
    [SerializeField] GameObject StartShowObject;
    [SerializeField] GameObject ExitButton;
    private Color color;
    bool isStart;

    [SerializeField] LoadingManager Loading;
    private void Start()
    {
        titleAudio.clip = Resources.Load<AudioClip>("Sounds/Title");
        titleAudio.Play();
        StartCoroutine("titlemove");
        color = titletext.GetComponent<Text>().color;
    }
    IEnumerator titlemove()
    {
        title.transform.DOLocalMove(Vector3.up * 30, 4);
        float timer = 1;
        while (timer > 0)
        {
            color.a = timer;
            timer -= Time.deltaTime / 2;
            yield return null;
        }
        title.transform.DOLocalMove(Vector3.down * 30, 4);
        while (timer < 1)
        {
            color.a = timer;
            timer += Time.deltaTime / 2;
            yield return null;
        }
        yield return StartCoroutine("titlemove");
    }
    public void CreatorButton()
    {
        titleAudio.PlayOneShot(Resources.Load<AudioClip>("Sounds/Button_Click"), 1);
        CreatorUI.transform.DOLocalMove(Vector3.zero, 1).SetEase(Ease.OutSine);
    }

    public void CreatorExitButton()
    {
        titleAudio.PlayOneShot(Resources.Load<AudioClip>("Sounds/Button_Click"), 1);
        CreatorUI.transform.DOLocalMove(Vector3.up * 1000, 1).SetEase(Ease.OutSine);
    }
    public void StartButton()
    {
        if (!isStart)
        {
            isStart = true;
            titleAudio.PlayOneShot(Resources.Load<AudioClip>("Sounds/Button_Click"), 1);
            StartCoroutine("StartShow");
        }
    }
    IEnumerator StartShow()
    {
        CreatorUI.transform.DOLocalMove(Vector3.up * 1000, 1).SetEase(Ease.OutSine);
        StartShowObject.transform.DOLocalMove(Vector3.up * 4000, 3).SetEase(Ease.InBack);
        CreatorButtons.transform.DOLocalMove(new Vector3(680, 620, 0), 1);
        ExitButton.transform.DOLocalMove(new Vector3(850, 620, 0), 1);
        titletext.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        Loading.Loading();
    }
    public void ExitButtons()
    {
        if (!isStart)
        {
            isStart = true;
            titleAudio.PlayOneShot(Resources.Load<AudioClip>("Sounds/Button_Click"), 1);
            StartCoroutine("ExitShow");
        }
    }
    IEnumerator ExitShow()
    {
        //CreatorUI.transform.DOLocalMove(Vector3.up * 1000, 1).SetEase(Ease.OutSine);
        //StartShowObject.transform.DOLocalMove(Vector3.up * 2900, 3).SetEase(Ease.InBack);
        //CreatorButtons.transform.DOLocalMove(new Vector3(680, 620, 0), 1);
        //ExitButton.transform.DOLocalMove(new Vector3(850, 620, 0), 1);
        //titletext.SetActive(false);
        //yield return new WaitForSeconds(3f);
        Application.Quit();
        yield return null;
    }
}
