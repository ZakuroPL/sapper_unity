using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicVAlue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int ThisSoundNumber = PlayerPrefs.GetInt("ThisSoundNumber", 0);
        //print("soundNumber is     " + ThisSoundNumber);
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("ThisSoundNumber") == 0)
        {

            backgroundMusicScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0.8f;
        }
        else if (PlayerPrefs.GetInt("ThisSoundNumber") != 0)
        {
            // backgroundMusicScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
            backgroundMusicScript.Instance.gameObject.GetComponent<AudioSource>().volume = 0f;
        }

    }
}
