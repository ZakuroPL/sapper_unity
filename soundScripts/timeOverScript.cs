using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeOverScript : MonoBehaviour
{

    AudioSource timeOver;
    void Start()
    {
        timeOver = GetComponent<AudioSource>();
        timeOver.volume = 1;
    }
    void Update()
    {
        if (timeOver.volume == 1)
        {
                 StartCoroutine(stopSound());
        }
        IEnumerator stopSound()
        {
            yield return new WaitForSeconds(2f);
            timeOver.volume = 0;
        }
    }
}
