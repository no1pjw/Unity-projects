using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int[] opponent_list = new int[10];
    public int[] player_list = new int[10];
    public GameObject[] card_numbers;
    public GameObject[] cards;
    public GameObject[] card_destination;
    public GameObject Game_progress_text;
    public GameObject Player_coin_text;
    public GameObject AI_coin_text;
    public GameObject Pot_text;
    public GameObject Player_state_text;
    public GameObject AI_state_text;
    public GameObject ten_coin_prefab;
    public GameObject one_coin_prefab;
    public bool player_turn = true;
    public GameObject[] buttons;
    public int player_coin = 20;
    public int ai_coin = 20;
    public int temp_coin = 0;
    public bool is_called = false;
    public bool player_die = false;
    public bool ai_die = false;
    public bool give_up = false;
    GameObject obj;
    public int turn = -1;
    public int max_betting_value = 1;
    public GameObject win_text;
    void Start()
    {
        Text player_state_text = Player_state_text.GetComponent<Text>();
        Text ai_state_text = AI_state_text.GetComponent<Text>();
        Text Win_text = win_text.GetComponent<Text>();
        player_state_text.color = new Color(player_state_text.color.r, player_state_text.color.g, player_state_text.color.b, 0);
        ai_state_text.color = new Color(ai_state_text.color.r, ai_state_text.color.g, ai_state_text.color.b, 0);
        Win_text.color = new Color(Win_text.color.r, Win_text.color.g, Win_text.color.b, 0);
        Game_progress_text.SetActive(false);
        for (int j = 0; j < 2; j++)
        {
            if (j == 0)
            {
                opponent_list = getRandomInt(10, 1, 11);
            }
            else
            {
                player_list = getRandomInt(10, 1, 11);
            }

        }
        for(int i = 0; i < 20; i++)
        {
 
            card_numbers[i].SetActive(false);
        }
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        // Update is called once per frame
        Invoke("Player_start", 2f);
    }
    void Update()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = Vector2.MoveTowards(cards[i].transform.position, card_destination[i].transform.position, 0.2f);
        }
        Player_coin_text.GetComponent<Text>().text = "Player coin : " + player_coin;
        AI_coin_text.GetComponent<Text>().text = "AI coin : " + ai_coin;
        Pot_text.GetComponent<Text>().text = "Pot coin : " + temp_coin;
    }

    public int[] getRandomInt(int length, int min, int max)
    {
        int[] randArray = new int[length];
        bool isSame;
        for (int i = 0; i < length; i++)
        {
            while (true)
            {
                randArray[i] = Random.Range(min, max);
                isSame = false;
                for (int j = 0; j < i; j++)
                {
                    if (randArray[j] == randArray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randArray;
    }

    public void Player_start()
    {
        GameObject obj3 = GameObject.Find("Raise_Event");
        GameObject obj4 = GameObject.Find("AI");
        obj3.GetComponent<Raise_button>().betting_value = 0;
        obj4.GetComponent<AI>().ai_betting = 1;
        Player_state_text.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        AI_state_text.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        turn++;
        is_called = false;
        player_die = false;
        ai_die = false;
        give_up = false;
        max_betting_value = 1;
        if (player_coin <= 0)
        {
            Ending(1);
        }
        if (ai_coin <= 0)
        {
            Ending(0);
        }
        if (turn == 10)
        {
            Ending(2);
        }
        else
        {
            player_coin -= 1;
            ai_coin -= 1;
            temp_coin += 2;
            obj = GameObject.Find("Player");
            GameObject obj2 = GameObject.Find("Call_Event");
            obj2.GetComponent<Call_button>().can_call = false;
            obj.GetComponent<Player>().ai_raised = false;
            obj.GetComponent<Player>().Player_Betting();
            player_turn = false;
        }
    }
    public void AI_start()
    {
        player_turn = true;
        obj = GameObject.Find("AI");
        obj.GetComponent<AI>().AI_Betting();
    }
    public void Card_Check(int player)
    {
        if (player == 0)
        {
            switch (opponent_list[turn])
            {
                case (1):
                    card_numbers[0].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[0].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (2):
                    card_numbers[1].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[1].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (3):
                    card_numbers[2].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[2].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (4):
                    card_numbers[3].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[3].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (5):
                    card_numbers[4].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[4].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (6):
                    card_numbers[5].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[5].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (7):
                    card_numbers[6].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[6].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (8):
                    card_numbers[7].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[7].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (9):
                    card_numbers[8].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[8].transform.position = card_destination[10 + turn].transform.position;
                    break;
                case (10):
                    card_numbers[9].SetActive(true);
                    cards[10 + turn].SetActive(false);
                    card_numbers[9].transform.position = card_destination[10 + turn].transform.position;
                    break;

            }
        }
        else
        {
            switch (player_list[turn])
            {
                case (1):
                    card_numbers[10].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[10].transform.position = card_destination[turn].transform.position;
                    break;
                case (2):
                    card_numbers[11].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[11].transform.position = card_destination[turn].transform.position;
                    break;
                case (3):
                    card_numbers[12].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[12].transform.position = card_destination[turn].transform.position;
                    break;
                case (4):
                    card_numbers[13].SetActive(true);
                    cards[ turn].SetActive(false);
                    card_numbers[13].transform.position = card_destination[turn].transform.position;
                    break;
                case (5):
                    card_numbers[14].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[14].transform.position = card_destination[turn].transform.position;
                    break;
                case (6):
                    card_numbers[15].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[15].transform.position = card_destination[turn].transform.position;
                    break;
                case (7):
                    card_numbers[16].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[16].transform.position = card_destination[turn].transform.position;
                    break;
                case (8):
                    card_numbers[17].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[17].transform.position = card_destination[turn].transform.position;
                    break;
                case (9):
                    card_numbers[18].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[18].transform.position = card_destination[turn].transform.position;
                    break;
                case (10):
                    card_numbers[19].SetActive(true);
                    cards[turn].SetActive(false);
                    card_numbers[19].transform.position = card_destination[turn].transform.position;
                    break;

            }
        }
      
    }
    public void Betting(int player, int betting)
    {
        int ten_value = betting / 10;
        int one_value = betting % 10;
        if(player == 0)
        {
            ai_coin -= betting;
            temp_coin += betting;
            max_betting_value = betting;
        }
        else
        {
            player_coin -= betting;
            temp_coin += betting;
            max_betting_value = betting;
        }
        if(!player_turn && turn == 9)
        {
            Ending(2);
        }
        if (is_called)
        {
            Game_progress_text.GetComponent<Text>().text = "승자를 확인합니다.";
            Invoke("Check_winner", 1f);
        }
        else
        {
            if (player == 0)
            {
                GameObject obj2 = GameObject.Find("Player");
                obj2.GetComponent<Player>().Player_setting();
            }
            else
            {
                AI_start();
            }
        }
    }
    public void Check_winner()
    {
        Card_Check(1);
        if (give_up)
        {
            if (player_die)
            {
                Game_progress_text.GetComponent<Text>().text = "AI가 승리하였습니다!";
                ai_coin += temp_coin;
                temp_coin = 0;
            }
            else
            {
                Game_progress_text.GetComponent<Text>().text = "플레이어가 승리하였습니다!";
                player_coin += temp_coin;
                temp_coin = 0;
            }
        }
        else
        {
            if(player_list[turn] > opponent_list[turn])
            {
                Game_progress_text.GetComponent<Text>().text = "플레이어가 승리하였습니다!";
                player_coin += temp_coin;
                temp_coin = 0;
            }
            else
            {
                Game_progress_text.GetComponent<Text>().text = "AI가 승리하였습니다!";
                ai_coin += temp_coin;
                temp_coin = 0;
            }
        }
        Invoke("Player_start", 1f);
    }
    public void nothing()
    {

    }
    public void Ending(int who_win)
    {
        GameObject obj = GameObject.Find("GameManager");
        GameObject obj4 = GameObject.Find("Color");
        int state = -1;
        if (who_win == 0)
        {
            Debug.Log("Player win!");
            state = 1;
        }
        else if(who_win == 1)
        {
            Debug.Log("Ai win!");
            state = 0;
        }
        else
        {
            if(player_coin > ai_coin)
            {
                Debug.Log("Player win!");
                state = 1;
            }
            else if(player_coin == ai_coin)
            {
                Debug.Log("Draw!");
                state = 2;
            }
            else
            {
                Debug.Log("Ai win!");
                state = 0;
            }
        }
        if(state == 0)
        {
            obj4.GetComponent<Color_script>().Yellow(win_text, 0);
        }
        else if(state == 1)
        {
            obj4.GetComponent<Color_script>().Yellow(win_text, 1);
        }
        else
        {
            obj4.GetComponent<Color_script>().Yellow(win_text, 2);
        }
    }
}
