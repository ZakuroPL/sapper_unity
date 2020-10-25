using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    private float moveSpeed = 0.8f;
    Rigidbody2D myBody;
    public GameObject mineEffect;
    public int ThisScene;
    public GameObject ShowMine;
    public GameObject textTimeOver;
    public GameObject textFinishLvl;
    public int NextScene;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>(); 
    }
    private void Start()
    {
        ShowMine.gameObject.SetActive(false);
        textFinishLvl.gameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        var clicked = false;
        var button = false;

        Vector3 LookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"), 50);
        if (LookVec.x != 0 && LookVec.y != 0)
        {
            transform.rotation = Quaternion.LookRotation(LookVec, Vector3.back);
            clicked = true;
            Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveSpeed;
            myBody.velocity = movement;
        }

        else if (!clicked)
        {
        clicked = false;
        myBody.velocity = Vector2.zero;
        }
        if (CrossPlatformInputManager.GetButton("Look") && CheckAmount.NumberOfCheck >0)
        {
            button = true;
            ShowMine.gameObject.SetActive(true);
            myBody.velocity = Vector2.zero;
        }
        else if (!button)
        {
            button = false;
            ShowMine.gameObject.SetActive(false);
        }
        if (textTimeOver.activeSelf)
        {
            moveSpeed = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Mine")
        {
            GameObject effect = Instantiate(mineEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            moveSpeed = 0;
            StartCoroutine(CallRestartLvl());
        }
        IEnumerator CallRestartLvl()
        {
            yield return new WaitForSeconds(0.8f);
            PlayerPrefs.SetInt("heartNumber", PlayerPrefs.GetInt("heartNumber") - 1);
            SceneManager.LoadScene(ThisScene);
        }
    if (collision.transform.tag == "NextLVL")
        {
            moveSpeed = 0;
            textFinishLvl.gameObject.SetActive(true);
            StartCoroutine(CallNextLvl());
        }
        IEnumerator CallNextLvl()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(NextScene);
            PlayerPrefs.SetInt("rateNumber", PlayerPrefs.GetInt("rateNumber") + 1);
            if (NextScene > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", NextScene - 1); // minus jeden poniewaz lvl2 jest na scenie 3. a odblowakony kwadrat 2 to wartosc 2

            }
            if (PlayerPrefs.GetInt("heartNumber") < 0)
            {
                PlayerPrefs.SetInt("heartNumber", PlayerPrefs.GetInt("heartNumber") + 1);
            }
        }
        if (collision.transform.tag == "UpToGame")
        {
            CheckAmount.NumberOfCheck += 1;
        }
        if (collision.transform.tag == "UpToGame2")
        {
            CheckAmount.NumberOfCheck += 2;
        }


    }


}
