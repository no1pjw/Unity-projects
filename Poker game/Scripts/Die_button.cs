using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Die_button : MonoBehaviour
{
    public GameObject Game_progress_text;
    public GameObject player_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        GameObject obj = GameObject.Find("GameManager");
        GameObject obj4 = GameObject.Find("Color");
        obj.GetComponent<GameManager>().player_die = true;
        obj.GetComponent<GameManager>().give_up = true;
        obj4.GetComponent<Color_script>().Blue(player_text, 1);
        Game_progress_text.GetComponent<Text>().text = "���ڸ� Ȯ���մϴ�.";
        Invoke("die", 1f);
    }
    public void die()
    {
        GameObject obj = GameObject.Find("GameManager");
        obj.GetComponent<GameManager>().Check_winner();
    }
}
