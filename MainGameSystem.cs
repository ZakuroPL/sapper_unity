using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class MainGameSystem : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject ratePanel;
    public GameObject continueButton;
    public GameObject trainingButton;
    public GameObject selectLvlButton;

    public Button[] lvlButtons;



    private int SceneForContinue;
    void Start()
    {
        Time.timeScale = 1;
        int levelAt = PlayerPrefs.GetInt("levelAt", 1); // zmien na 1
        int heartNumber = PlayerPrefs.GetInt("heartNumber", 0);
        int rateNumber = PlayerPrefs.GetInt("rateNumber", 0);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                lvlButtons[i].interactable = false;

        }
        print("heart " + heartNumber);
        print("rate " + rateNumber);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("levelAt")< 2)
        {
            continueButton.gameObject.SetActive(false);
            trainingButton.gameObject.SetActive(true);
            selectLvlButton.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("levelAt") > 1)
        {
            continueButton.gameObject.SetActive(true);
            trainingButton.gameObject.SetActive(false);
            selectLvlButton.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("rateNumber") > 7 && PlayerPrefs.GetInt("rateNumber") < 100)
        {
            ratePanel.gameObject.SetActive(true);
        }
    }
    public void exitThisGame()
    {
        Application.Quit();
    }
    public void Controling(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1;
        //by Damian Granatowski
    }
    public void ActiveMenu()
    {
        Panel1.gameObject.SetActive(true);
    }
    public void DisActiveMenu()
    {
        Panel1.gameObject.SetActive(false);
    }
    public void DisActiveMenu2()
    {
        Panel2.gameObject.SetActive(false);
    }
    public void DisActiveMenu3()
    {
        Panel3.gameObject.SetActive(false);
    }
    public void DisActiveMenu4()
    {
        Panel4.gameObject.SetActive(false);
    }
    public void Page1to2()
    {
        Panel2.gameObject.SetActive(true);
        Panel1.gameObject.SetActive(false);
    }
    public void Page2to3()
    {
        Panel3.gameObject.SetActive(true);
        Panel2.gameObject.SetActive(false);
    }
    public void Page2to1()
    {
        Panel1.gameObject.SetActive(true);
        Panel2.gameObject.SetActive(false);
    }
    public void Page3to4()
    {
        Panel4.gameObject.SetActive(true);
        Panel3.gameObject.SetActive(false);
    }
    public void Page3to2()
    {
        Panel2.gameObject.SetActive(true);
        Panel3.gameObject.SetActive(false);
    }
    public void Page4to3()
    {
        Panel3.gameObject.SetActive(true);
        Panel4.gameObject.SetActive(false);
    }
    public void ContinueScene()
    {
        SceneForContinue = PlayerPrefs.GetInt("levelAt");
        if (SceneForContinue != 0)
        {
            SceneManager.LoadScene(SceneForContinue +1); // poniewaz w player jest minus jeden.
        }
        else if (SceneForContinue <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void CliclForRate()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Czamarka.SapperWar2DMinefield");
        PlayerPrefs.SetInt("rateNumber", PlayerPrefs.GetInt("rateNumber") + 500);
        ratePanel.gameObject.SetActive(false);
    }
    public void CliclForLater()
    {
        PlayerPrefs.SetInt("rateNumber", PlayerPrefs.GetInt("rateNumber") - 20);
        ratePanel.gameObject.SetActive(false);
    }
    public void CliclForNoRate()
    {
        PlayerPrefs.SetInt("rateNumber", PlayerPrefs.GetInt("rateNumber") - 40);
        ratePanel.gameObject.SetActive(false);
    }

}
//          