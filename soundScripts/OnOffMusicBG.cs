using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffMusicBG : MonoBehaviour
{
    public GameObject glosnikON;
    public GameObject glosnikOFF;


    void Update()
    {
        if (PlayerPrefs.GetInt("ThisSoundNumber") == 0)
        {
            
            backgroundMusicScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0.8f;
            glosnikON.gameObject.SetActive(true);
            glosnikOFF.gameObject.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("ThisSoundNumber") != 0)
        {
            // backgroundMusicScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
            backgroundMusicScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0f;
            glosnikOFF.gameObject.SetActive(true);
            glosnikON.gameObject.SetActive(false);
        }
        
    }
    public void ButtonControl() 
    { 
        if (PlayerPrefs.GetInt("ThisSoundNumber") == 0)
        {
            PlayerPrefs.SetInt("ThisSoundNumber", PlayerPrefs.GetInt("ThisSoundNumber") + 1);
            //print("SOUND PLUS");
        }
        else if (PlayerPrefs.GetInt("ThisSoundNumber") != 0)
        {
            PlayerPrefs.SetInt("ThisSoundNumber", PlayerPrefs.GetInt("ThisSoundNumber") - 1);
            //print("SOUND MINUS");
        }
        
    }
}
