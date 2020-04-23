using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Variable to change speed in Inspector
    public float speed = 6.0f;

    Rigidbody2D Rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY -= 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1f;
        }

        // normalized returns the Vector with a magnitude of 1 - good for movement
        Vector3 moveDir = new Vector3(moveX, moveY).normalized;

        transform.position += moveDir * speed * Time.deltaTime;
    }
}
