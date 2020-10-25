using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementMainMenu : MonoBehaviour
{
    Rigidbody2D followPoint;
    private float speed = 0.05f;

    private void Start()
    {
        followPoint = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 movement = new Vector2(0, 10 * speed);
        followPoint.velocity = movement;
    }
}
