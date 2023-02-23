using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager_win : MonoBehaviour
{
    public GameObject win_text;
    // Start is called before the first frame update
    void Start()
    {
        Yellow(win_text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Yellow(GameObject obj)
    {
        Text text = obj.GetComponent<Text>();
        text.color = new Color(255, 255, 0, 0);

        StartCoroutine("Win_FadeIn");
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
    public void onClick()
    {
        SceneManager.LoadScene("GameScene_AI");
    }
}
