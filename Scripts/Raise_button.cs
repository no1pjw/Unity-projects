using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Raise_button : MonoBehaviour
{
    public InputField betting_input;
    public GameObject[] game_objects;
    public GameObject player_text;
    public int betting_value;
    bool is_wrong = false;
    public void ButtonClick()
    {
        for(int i = 0; i < game_objects.Length; i++)
        {
            game_objects[i].SetActive(true);
        }
    }
    public void OK_Click()
    {
        GameObject obj = GameObject.Find("GameManager");
        GameObject obj2 = GameObject.Find("Player");
        GameObject obj3 = GameObject.Find("Call_Event");
        int player_temp_coin = obj.GetComponent<GameManager>().player_coin;
        if (!is_wrong && (betting_value <= player_temp_coin) && betting_value > 0 && (betting_value > obj.GetComponent<GameManager>().max_betting_value) && betting_value != 1)
        {
            obj3.GetComponent<Call_button>().can_call = true;
            for(int i = 0; i < game_objects.Length; i++)
            {
                game_objects[i].SetActive(false);
            }
            obj.GetComponent<GameManager>().Betting(1, betting_value);
        }
        else
        {
      
            betting_input.text = "잘못된 입력입니다.";
        }
    }
    public void check_betting_value(InputField betting_num)
    {
        is_wrong = false;
        try
        {
            betting_value = int.Parse(betting_num.text);
        }
        catch(FormatException)
        {
            betting_num.text = "잘못된 입력입니다.";
            is_wrong = true;
        }
    }
}
