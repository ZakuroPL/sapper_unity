using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainingSystemMenu : MonoBehaviour
{

    public GameObject les1;
    public GameObject les2;
    public GameObject les3;
    public GameObject les4;
    public GameObject les5;

    public void goTo2()
    {
        les1.gameObject.SetActive(false);
        les2.gameObject.SetActive(true);
    }
    public void goTo3()
    {
        les2.gameObject.SetActive(false);
        les3.gameObject.SetActive(true);
    }
    public void goTo4()
    {
        les3.gameObject.SetActive(false);
        les4.gameObject.SetActive(true);
    }
    public void goTo5()
    {
        les4.gameObject.SetActive(false);
        les5.gameObject.SetActive(true);
    }
    public void goToExit()
    {
        les5.gameObject.SetActive(false);
    }

}
