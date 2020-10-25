using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckAmount : MonoBehaviour
{
    Text text;
    public static int NumberOfCheck;
    void Start()
    {
        text = GetComponent<Text>();
        NumberOfCheck = 2;
    }


    void Update()
    {
        text.text = "x" + NumberOfCheck;
        if(NumberOfCheck <= 0)
        {
            NumberOfCheck = 0;
        }
    }
}
