using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Call_button : MonoBehaviour
{
    public GameObject[] game_objects;
    public GameObject Game_progress_text;
    public GameObject player_text;
    public bool can_call = false;
    public int call_value = 0;
    // Start is called before the first frame update
    void Start()
        
    {
        for(int i = 0; i < game_objects.Length; i++)
        {
            game_objects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick()
    {
        GameObject obj = GameObject.Find("GameManager");
        GameObject obj2 = GameObject.Find("Raise_Event");
        GameObject obj4 = GameObject.Find("Color");
        int call_betting = obj.GetComponent<GameManager>().max_betting_value - obj2.GetComponent<Raise_button>().betting_value - 1;
        if (can_call)
        {
            obj.GetComponent<GameManager>().is_called = true;
            obj4.GetComponent<Color_script>().Green(player_text, 1);
            if (obj.GetComponent<GameManager>().player_coin < call_betting)
            {
                obj.GetComponent<GameManager>().Betting(1, obj.GetComponent<GameManager>().player_coin);
            }
            else
            {
                obj.GetComponent<GameManager>().Betting(1, call_betting);
            }
            
        }
        else
        {

                Game_progress_text.GetComponent<Text>().text = "지금은 할 수 없습니다.";
            
        }
        }
}
