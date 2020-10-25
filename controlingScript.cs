using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlingScript : MonoBehaviour
{
    public int ThisScene;
    public void controlling()
    {
        SceneManager.LoadScene(ThisScene);
    }
}
