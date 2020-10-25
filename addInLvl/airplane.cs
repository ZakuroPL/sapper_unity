using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplane : MonoBehaviour
{
    Rigidbody2D aircraft;
    private float speed = 0.5f;
    public GameObject thisObject;


    private void Start()
    {
        aircraft = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

            Vector2 movement = new Vector2(0, 10 * speed);
            aircraft.velocity = movement;
        StartCoroutine(delete());
        IEnumerator delete()
        {
            yield return new WaitForSeconds(8f);
            thisObject.gameObject.SetActive(false);
        }
    }
}//end
