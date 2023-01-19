using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Color_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Red(GameObject obj)
    {
        Text text = obj.GetComponent<Text>();
        Color c = text.color;
        
    }
    public void Blue(GameObject obj)
    {

    }
    public void Green(GameObject obj)
    {

    }
}
