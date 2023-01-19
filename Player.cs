using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Game_progress_text;
    public GameObject[] buttons;
    public InputField betting_input;
    public GameObject Call_text;
    public bool ai_raised = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Player_Betting()
    {
        Player_setting();
        GameObject obj = GameObject.Find("GameManager");
        obj.GetComponent<GameManager>().Card_Check(0);
    }
    public void Player_setting()
    {
        GameObject obj = GameObject.Find("GameManager");
        GameObject obj2 = GameObject.Find("Raise_Event");
        int call_betting = obj.GetComponent<GameManager>().max_betting_value - obj2.GetComponent<Raise_button>().betting_value - 1;
        if (!(ai_raised))
        {
            Game_progress_text.GetComponent<Text>().text = "플레이어 차례입니다.";
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
        Game_progress_text.SetActive(true);
        if (obj.GetComponent<GameManager>().player_coin < call_betting)
        {
            Call_text.GetComponent<Text>().text = "Call(all-in)";
        }
        else
        {
            Call_text.GetComponent<Text>().text = "Call(" + call_betting +")";
        }
    }
}
