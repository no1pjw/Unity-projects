using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Game_progress_text;
    public GameObject Ai_state_text;
    public float win_probability;
    public int ai_betting = 1;
    public int[] ban_card = new int[10];
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
        GameObject obj4 = GameObject.Find("Color");
        int present_turn = obj.GetComponent<GameManager>().turn;
        for(int i = 0; i < present_turn; i++)
        {
            ban_card[i] = obj.GetComponent<GameManager>().opponent_list[i];
        }
        int present_card = obj.GetComponent<GameManager>().player_list[present_turn];
        float win_probability = check_probability(present_turn, present_card);
        float call_set = 1.0f;
        float die_set = 2.0f;
        if (win_probability > 0.8)
        {
            call_set = -1.0f;
            die_set = -1.0f;
        }
        else if (win_probability > 0.7)
        {
            call_set = 0.9f;
            die_set = 1.3f;
        }
        else if (win_probability > 0.6)
        {
            call_set = 1.0f;
            die_set = 1.6f;
        }
        else if (win_probability > 0.5)
        {
            call_set = 0.8f;
            die_set = 1.7f;
        }
        else if (win_probability > 0.4)
        {
            call_set = 0.6f;
            die_set = 2.3f;
        }
        else if (win_probability > 0.3) {
            call_set = 0.5f;
            die_set = 2.4f;
        }
        else
        {
            call_set = 0.3f;
            die_set = 2.6f;
        }
       
        while (true)
        {
            float state = Random.Range(0.0f, 3.0f);
            Debug.Log(win_probability);
            Debug.Log(state);
            if (state <= call_set)
            {
                int betting = obj.GetComponent<GameManager>().max_betting_value - ai_betting;
                obj.GetComponent<GameManager>().is_called = true;
                obj4.GetComponent<Color_script>().Green(Ai_state_text, 0);
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
            else if (state <= die_set)
            {
                obj.GetComponent<GameManager>().ai_die = true;
                obj.GetComponent<GameManager>().give_up = true;
                obj4.GetComponent<Color_script>().Blue(Ai_state_text, 0);
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
                obj4.GetComponent<Color_script>().Red(Ai_state_text, 0);
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

    public float check_probability(int present_turn, int present_card)
    {
        int win_banned = 0;
        for(int i = 1; i <= 10; i++)
        {
            if (i >= present_card)
            {
                for(int j = 0; j < present_turn; j++)
                {
                    if ( i == ban_card[j])
                    {
                        win_banned += 1;
                        break;
                    }
                }
            }
        }
        return (float)(10 - present_card - win_banned) / (10 - present_turn);
    }
}
