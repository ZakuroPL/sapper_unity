using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCompleteScript : MonoBehaviour
{
    AudioSource levelComplete;
    void Start()
    {
        levelComplete = GetComponent<AudioSource>();
        levelComplete.volume = 1;
    }
    void Update()
    {
        if (levelComplete.volume == 1)
        {
            StartCoroutine(stopSound());
        }
        IEnumerator stopSound()
        {
            yield return new WaitForSeconds(2f);
            levelComplete.volume = 0;
        }
    }
}
