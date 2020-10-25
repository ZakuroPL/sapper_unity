using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusicScript : MonoBehaviour
{
    AudioSource soundOfMusic;

    private static backgroundMusicScript instance = null;
    public static backgroundMusicScript Instance
    { get {return instance;}}

    private void Awake()
    {
      if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
