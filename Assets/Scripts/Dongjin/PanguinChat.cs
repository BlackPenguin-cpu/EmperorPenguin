using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanguinChat : MonoBehaviour
{
    [SerializeField] float ChatTime;
    [SerializeField] GameObject Chat;
    private void Start()
    {
        StartCoroutine("Chatting");
    }
    IEnumerator Chatting()
    {
        yield return new WaitForSeconds(ChatTime);
        float timer = 1; 
        GameObject RandomChat = Chat.transform.GetChild(Random.Range(0,Chat.transform.childCount)).gameObject;
        RandomChat.transform.position = Camera.main.WorldToScreenPoint(transform.position+Vector3.up*1.5f);
        Color color = RandomChat.GetComponent<Image>().color;
        color.a = timer;
        RandomChat.GetComponent<Image>().color = color;
        RandomChat.transform.GetChild(0).GetComponent<Text>().color = new Color(0, 0, 0, timer);
        yield return new WaitForSeconds(1);
        while (timer >= 0)
        {
            color.a = timer;
            RandomChat.GetComponent<Image>().color = color;
            RandomChat.transform.GetChild(0).GetComponent<Text>().color = new Color(0,0,0,timer);
            timer -= Time.deltaTime/2;
            yield return null;
        }
        StartCoroutine("Chatting");
        yield return null;
    }
}
