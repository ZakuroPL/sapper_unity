using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class ButtonMinus : MonoBehaviour
{
    public GameObject PausePanel;
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Pause"))
        {
            active();
        }
        if (CrossPlatformInputManager.GetButtonDown("Back"))
        {
            disactive();
        }
        if (CrossPlatformInputManager.GetButtonDown("Menu"))
        {
            OpenMenu();
        }
    }
    public void active()
    {
        PausePanel.gameObject.SetActive(true);
       
    }
    public void disactive()
    {
        PausePanel.gameObject.SetActive(false);
       
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(1);
        //AudioListener.volume = 1;
    }
    
    public void minusOne()
    {
        if(CheckAmount.NumberOfCheck > 0)
        CheckAmount.NumberOfCheck -= 1;
    }


}
