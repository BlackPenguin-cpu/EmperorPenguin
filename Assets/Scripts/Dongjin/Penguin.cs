using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Penguin : MonoBehaviour
{

    [SerializeField] float chatTime;
    [SerializeField] GameObject chat;
    [SerializeField] Sprite[] anime;
    private int idx = 0;
    public int penguinidx;
    private void Start()
    {
        StartCoroutine("Chatting");
        StartCoroutine("AnimaSwap");
    }
    IEnumerator Chatting()
    {
        yield return new WaitForSeconds(chatTime);
        if (Random.Range(0, 3) == 0)
        {
            SoundManager.Instance.PlaySound("Penguin", SoundType.SE, 15, 1);
            float timer = 1;
            GameObject RandomChat = chat.transform.GetChild(Random.Range(0, chat.transform.childCount)).gameObject;
            RandomChat.transform.position = transform.position + new Vector3(2.1f, 2.3f, 0);
            Color color = RandomChat.GetComponent<Image>().color;
            color.a = timer;
            RandomChat.GetComponent<Image>().color = color;
            RandomChat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, timer);
            yield return new WaitForSeconds(1);
            while (timer >= 0)
            {
                color.a = timer;
                RandomChat.GetComponent<Image>().color = color;
                RandomChat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, timer);
                timer -= Time.deltaTime / 2;
                yield return null;
            }
            RandomChat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
        }
        StartCoroutine("Chatting");
        yield return null;
    }
    IEnumerator AnimaSwap()
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        idx = idx * -1 + 1;
        GetComponent<SpriteRenderer>().sprite = anime[idx];
        StartCoroutine("AnimaSwap");
        yield return null;
    }
}
