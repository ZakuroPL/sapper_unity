using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeAirplane : MonoBehaviour
{
    public GameObject thisObject;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            thisObject.gameObject.SetActive(true);
        }
          
    }
}
