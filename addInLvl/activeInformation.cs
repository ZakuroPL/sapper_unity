using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeInformation : MonoBehaviour
{
    public GameObject thisObject;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            thisObject.gameObject.SetActive(true);
            StartCoroutine(delete());
            IEnumerator delete()
            {
                yield return new WaitForSeconds(2f);
                thisObject.gameObject.SetActive(false);
            }
        }

    }
}
