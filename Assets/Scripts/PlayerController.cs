using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Variable to change speed in Inspector
    public float speed = 6.0f;

    Vector2 lookDirection = new Vector2(1, 0);

    Rigidbody2D Rigidbody2d;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float MoveX = 0f;
        float MoveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            MoveY = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveX = +1f;
        }

        // normalized returns the Vector with a magnitude of 1 - good for movement
        Vector2 moveDir = new Vector2(MoveX, MoveY);
        Debug.Log(moveDir);

        if (!Mathf.Approximately(moveDir.x, 0.0f) || !Mathf.Approximately(moveDir.y, 0.0f))
        {
            lookDirection.Set(moveDir.x, moveDir.y);
            lookDirection.Normalize();
        }

        Debug.Log(lookDirection.x);

        //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", lookDirection.x);

        Rigidbody2d.position = Rigidbody2d.position + (moveDir * speed * Time.deltaTime);

        Rigidbody2d.MovePosition(Rigidbody2d.position);
    }
}
