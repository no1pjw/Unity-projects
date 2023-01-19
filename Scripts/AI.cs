using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Game_progress_text;
    public float win_probability;
    public int ai_betting = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AI_Betting()
    {
        Game_progress_text.SetActive(true);
        Game_progress_text.GetComponent<Text>().text = "AI가 플레이 중입니다 . . .";
        Invoke("AI_Real_Betting", 1.5f);
    }
    public void AI_Real_Betting()
    {
        Game_progress_text.SetActive(true);
        GameObject obj = GameObject.Find("GameManager");
        GameObject obj2 = GameObject.Find("Raise_Event");
        GameObject obj3 = GameObject.Find("Player");
        while (true)
        {
            int state = Random.Range(0, 3);
            if (state == 0)
            {
                int betting = obj.GetComponent<GameManager>().max_betting_value - ai_betting;
                obj.GetComponent<GameManager>().is_called = true;
                if (betting > obj.GetComponent<GameManager>().ai_coin)
                {
                    obj.GetComponent<GameManager>().Betting(0, obj.GetComponent<GameManager>().ai_coin);
                }
                else
                {
                    obj.GetComponent<GameManager>().Betting(0, betting);
                }
                break;
            }
            else if (state == 1)
            {
                obj.GetComponent<GameManager>().ai_die = true;
                obj.GetComponent<GameManager>().give_up = true;
                Game_progress_text.GetComponent<Text>().text = "승자를 확인합니다.";
                Invoke("call", 1f);
                break;
            }
            else
            {
                int betting_value = Random.Range(obj.GetComponent<GameManager>().max_betting_value + 1, obj.GetComponent<GameManager>().ai_coin + 1);
                ai_betting = betting_value;
                if(betting_value > obj.GetComponent<GameManager>().ai_coin)
                {
                    continue;
                }
                Game_progress_text.GetComponent<Text>().text = "AI가 " + betting_value + "만큼 추가 베팅하였습니다.";
                obj3.GetComponent<Player>().ai_raised = true;
                obj.GetComponent<GameManager>().Betting(0, betting_value);
                break;
            }
        }
    }
    public void call()
    {
        GameObject obj = GameObject.Find("GameManager");
        obj.GetComponent<GameManager>().Check_winner();
    }

}
