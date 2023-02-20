using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Color_script : MonoBehaviour
{
    public GameObject player_state_text;
    public GameObject ai_state_text;
    public GameObject win_text;
    // Start is called before the first frame update
    void Start()
        
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Red(GameObject obj, int player)
    {
        Text text = obj.GetComponent<Text>();
        text.text = "Raise!";
        text.color = new Color(255, 0, 0, 0);
        if (player == 0)
        {
            StartCoroutine("AI_FadeIn");
        }
        else
        {
            StartCoroutine("Player_FadeIn");
        }
    }
    public void Blue(GameObject obj, int player)
    {
        Text text = obj.GetComponent<Text>();
        text.text = "Die..";
        text.color = new Color(0, 0, 255, 0);
        if (player == 0)
        {
            StartCoroutine("AI_FadeIn");
        }
        else
        {
            StartCoroutine("Player_FadeIn");
        }
    }
    public void Green(GameObject obj, int player)
    {
        Text text = obj.GetComponent<Text>();
        text.text = "Call!";
        text.color = new Color(0, 255, 0, 0);
        if (player == 0)
        {
            StartCoroutine("AI_FadeIn");
        }
        else
        {
            StartCoroutine("Player_FadeIn");
        }
    }
    public void Yellow(GameObject obj, int player)
    {
        Text text = obj.GetComponent<Text>();
        text.color = new Color(255, 255, 0, 0);
        if (player == 0)
        {
            text.text = "AI win!";
        }
        else if(player == 1)
        {
            text.text = "Player win!";
        }
        else
        {
            text.text = "Draw!";
        }
        StartCoroutine("Win_FadeIn");
    }
    IEnumerator Player_FadeIn()
    {
        Text text = player_state_text.GetComponent<Text>();
        
        for(int i = 0; i < 10; i++)
        {
            float f = i / 10.0f;
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator AI_FadeIn()
    {
        Text text = ai_state_text.GetComponent<Text>();

        for (int i = 0; i < 10; i++)
        {
            float f = i / 10.0f;
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator Win_FadeIn()
    {
        Text text = win_text.GetComponent<Text>();

        for (int i = 0; i < 10; i++)
        {
            float f = i / 10.0f;
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
