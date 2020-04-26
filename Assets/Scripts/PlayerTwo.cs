using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{

    Rigidbody2D rgb2D;
    Animator animator;
    Vector2 position,scale;

    public float SPEED = 6.0f;
    bool idle = true;

    // Start is called before the first frame update
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        position = rgb2D.position;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = 0.0f;
        
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1.0f;
            scale.x = +1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1.0f;
            scale.x = -1;
        }

        if(!(Mathf.Approximately(moveX, 0.0f)))
        {
            idle = false;
        }
        else
        {
            idle = true;
        }

        Vector2 moveDir = new Vector2(moveX, 0);

        animator.SetFloat("Speed", moveX);
        animator.SetBool("Idle", idle);

        position = position + (moveDir * SPEED * Time.deltaTime);

        rgb2D.MovePosition(position);
        transform.localScale = scale;
    }
}
