using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float startTime;
    public int ThisScene;
    public GameObject text0Time;
    public GameObject textFinishLvl;
    public Animator anim;
    public GameObject livePanel;
    public GameObject PausePanel;

    AudioSource soundOfTimer;

    float timerTime = 0f;
    Text text;
    void Start()
    {
        Time.timeScale = 1;
        text = GetComponent<Text>();
        timerTime = startTime;
        soundOfTimer = GetComponent<AudioSource>();
        soundOfTimer.volume = 0;
        text0Time.gameObject.SetActive(false);
     
     
    }

    void Update()
    {
        heartSystem();
        timerTime -= 1 * Time.deltaTime;
        text.text = timerTime.ToString("0");
       

        if (timerTime <= 0)
        {
            timerTime = 0;
            StartCoroutine(startRestart());
            text0Time.gameObject.SetActive(true);
            soundOfTimer.volume = 0;
        }
        if (timerTime <= 10 && timerTime >0)
        {
            soundOfTimer.volume = 0.2f;
            StartCoroutine(startSound());
        }
        IEnumerator startSound()
        {
            yield return new WaitForSeconds(0.4f);
            text.color = Color.red;
        }
        IEnumerator startRestart()
        {
            yield return new WaitForSeconds(2f);
            PlayerPrefs.SetInt("heartNumber", PlayerPrefs.GetInt("heartNumber") - 1);
            SceneManager.LoadScene(ThisScene);
        }
        if (textFinishLvl.activeSelf)
        {
            soundOfTimer.volume = 0;
            timerTime += 1 * Time.deltaTime;

        }
    
        if (PausePanel.gameObject.activeSelf)
        {
            Time.timeScale = 0;
        }
        else if (livePanel.gameObject.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
      
    }

    void heartSystem()
    {
        if (PlayerPrefs.GetInt("heartNumber") < -3)
        {
            PlayerPrefs.SetInt("heartNumber", -3);
        }

        if (PlayerPrefs.GetInt("heartNumber") > 0)
        {
            anim.gameObject.SetActive(false);
            livePanel.gameObject.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("heartNumber") == 0)
        {
            anim.SetBool("b3", true);
            anim.SetBool("b2", false);
            anim.SetBool("b1", false);
            anim.SetBool("b0", false);
            livePanel.gameObject.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("heartNumber") == -1)
        {
            anim.SetBool("b3", false);
            anim.SetBool("b2", true);
            anim.SetBool("b1", false);
            anim.SetBool("b0", false);
            livePanel.gameObject.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("heartNumber") == -2)
        {
            anim.SetBool("b3", false);
            anim.SetBool("b2", false);
            anim.SetBool("b1", true);
            anim.SetBool("b0", false);
            livePanel.gameObject.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("heartNumber") == -3)
        {
            anim.SetBool("b3", false);
            anim.SetBool("b2", false);
            anim.SetBool("b1", false);
            anim.SetBool("b0", true);
            livePanel.gameObject.SetActive(true);
            
        }
    }
    public void buttonWatch()
    {
       StartForGoogle.instance.ShowRewardedAd();
       PlayerPrefs.SetInt("heartNumber", PlayerPrefs.GetInt("heartNumber") + 1);
        //PlayerPrefs.SetInt("heartNumber", PlayerPrefs.GetInt("heartNumber") + 1000);//for tasting in unity

    }
    public void buttonBuy()
    {
        AIPmanager.Instance.BuyNonConsumable();
    }


    
} //END
